using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



namespace BankSystem
{
    public partial class Index7 : System.Web.UI.Page
    {
        static string connectionString = "Server=localhost;Database=BankSystem;User Id=sa;Password=sa123456;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IBAN"] == null)
                {
                    Response.Redirect("Index2.aspx"); 
                }
            }
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            // التحقق من إدخال البيانات
            if (decimal.TryParse(AmountTextBox.Text.Trim(), out decimal paymentAmount) && !string.IsNullOrEmpty(BillNumberTextBox.Text))
            {
                string billType = BillTypeDropDown.SelectedValue; 
                string userIban = Session["IBAN"].ToString(); 
                string billNo = BillNumberTextBox.Text.Trim(); // رقم الفاتورة الجديد (BillNo)

                if (paymentAmount <= 0)
                {
                    MessageLabel.Text = "Tutar pozitif bir değer olmalıdır.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                
                if (CheckUserBalance(userIban, paymentAmount))
                {
                    
                    if (IsBillAlreadyPaid(billNo))
                    {
                        MessageLabel.Text = "Bu fatura zaten ödenmiş.";
                        MessageLabel.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    
                    if (ProcessBillPayment(userIban, paymentAmount, billType, billNo))
                    {
                        MessageLabel.Text = "Fatura ödeme işlemi başarılı!";
                        MessageLabel.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        MessageLabel.Text = "Fatura ödeme işlemi sırasında bir hata oluştu.";
                        MessageLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    MessageLabel.Text = "Yetersiz bakiye.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                MessageLabel.Text = "Lütfen geçerli bir tutar ve fatura numarası giriniz.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        
        private bool CheckUserBalance(string iban, decimal paymentAmount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Balance FROM Users WHERE IBAN = @IBAN";
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IBAN", iban);
                        object balanceObj = command.ExecuteScalar();
                        if (balanceObj != null && balanceObj != DBNull.Value)
                        {
                            decimal currentBalance = Convert.ToDecimal(balanceObj);
                            return currentBalance >= paymentAmount;
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = "Veritabanı hatası: " + ex.Message;
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }
        }

        
        private bool IsBillAlreadyPaid(string billNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Paid FROM Bills WHERE BillNo = @BillNo";
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BillNo", billNo);
                        object paidObj = command.ExecuteScalar();
                        if (paidObj != null && paidObj != DBNull.Value)
                        {
                            bool isPaid = Convert.ToBoolean(paidObj);
                            return isPaid; 
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = "Veritabanı hatası: " + ex.Message;
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }
        }

        
        private bool ProcessBillPayment(string iban, decimal paymentAmount, string billType, string billNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateBalanceQuery = "UPDATE Users SET Balance = Balance - @PaymentAmount WHERE IBAN = @IBAN";
                string updateBillQuery = "UPDATE Bills SET Paid = 1 WHERE BillNo = @BillNo";

                try
                {
                    connection.Open();
                    using (SqlCommand updateCommand = new SqlCommand(updateBalanceQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@IBAN", iban);
                        updateCommand.Parameters.AddWithValue("@PaymentAmount", paymentAmount);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        
                        if (rowsAffected > 0)
                        {
                            
                            using (SqlCommand billCommand = new SqlCommand(updateBillQuery, connection))
                            {
                                billCommand.Parameters.AddWithValue("@BillNo", billNo);
                                billCommand.ExecuteNonQuery();
                            }

                            
                            RecordBillPayment(iban, paymentAmount, billType, billNo);
                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = "Veritabanı hatası: " + ex.Message;
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }
        }

        private void RecordBillPayment(string iban, decimal paymentAmount, string billType, string billNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertPaymentQuery = "INSERT INTO BillPayments (IBAN, PaymentAmount, BillType, BillNo, Date) VALUES (@IBAN, @PaymentAmount, @BillType, @BillNo, @Date)";
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertPaymentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IBAN", iban);
                        command.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                        command.Parameters.AddWithValue("@BillType", billType);
                        command.Parameters.AddWithValue("@BillNo", billNo);
                        command.Parameters.AddWithValue("@Date", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = "Veritabanı hatası: " + ex.Message;
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}

