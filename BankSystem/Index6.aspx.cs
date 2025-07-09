using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace BankSystem
{
    public partial class Index6 : System.Web.UI.Page
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

        protected void TransferButton_Click(object sender, EventArgs e)
        {
            // التحقق من إدخال المبلغ
            if (decimal.TryParse(AmountTextBox.Text.Trim(), out decimal transferAmount))
            {
                string recipientIban = RecipientTextBox.Text.Trim(); // رقم حساب المستلم
                string senderIban = Session["IBAN"].ToString(); // رقم حساب المرسل

                if (transferAmount <= 0)
                {
                    MessageLabel.Text = "Tutar pozitif bir değer olmalıdır.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (string.IsNullOrEmpty(recipientIban))
                {
                    MessageLabel.Text = "Lütfen geçerli bir alıcı hesap numarası giriniz.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (CheckSenderBalance(senderIban, transferAmount))
                {
                    if (TransferAmount(senderIban, recipientIban, transferAmount))
                    {
                        MessageLabel.Text = "Transfer işlemi başarılı!";
                        MessageLabel.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        MessageLabel.Text = "Transfer işlemi sırasında bir hata oluştu.";
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
                MessageLabel.Text = "Lütfen geçerli bir tutar giriniz.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool CheckSenderBalance(string iban, decimal transferAmount)
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
                            return currentBalance >= transferAmount;
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

        private bool TransferAmount(string senderIban, string recipientIban, decimal transferAmount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deductQuery = "UPDATE Users SET Balance = Balance - @TransferAmount WHERE IBAN = @SenderIBAN";
                string addQuery = "UPDATE Users SET Balance = Balance + @TransferAmount WHERE IBAN = @RecipientIBAN";

                try
                {
                    connection.Open();
                    using (SqlCommand deductCommand = new SqlCommand(deductQuery, connection))
                    {
                        deductCommand.Parameters.AddWithValue("@SenderIBAN", senderIban);
                        deductCommand.Parameters.AddWithValue("@TransferAmount", transferAmount);
                        int senderRowsAffected = deductCommand.ExecuteNonQuery();

                        if (senderRowsAffected > 0)
                        {
                            using (SqlCommand addCommand = new SqlCommand(addQuery, connection))
                            {
                                addCommand.Parameters.AddWithValue("@RecipientIBAN", recipientIban);
                                addCommand.Parameters.AddWithValue("@TransferAmount", transferAmount);
                                int recipientRowsAffected = addCommand.ExecuteNonQuery();

                                return recipientRowsAffected > 0;
                            }
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
    }
}
