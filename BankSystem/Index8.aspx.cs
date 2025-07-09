using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace BankSystem
{
    public partial class Index8 : System.Web.UI.Page
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

        protected void PayTaxButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text.Trim(), out decimal taxAmount) && !string.IsNullOrEmpty(TaxNumberTextBox.Text))
            {
                string taxType = TaxTypeDropDown.SelectedValue;
                string userIban = Session["IBAN"].ToString();
                string taxNo = TaxNumberTextBox.Text.Trim();

                if (taxAmount <= 0)
                {
                    MessageLabel.Text = "Tutar pozitif bir değer olmalıdır.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (CheckUserBalance(userIban, taxAmount))
                {
                    if (IsTaxAlreadyPaid(taxNo))
                    {
                        MessageLabel.Text = "Bu vergi zaten ödenmiş.";
                        MessageLabel.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    if (ProcessTaxPayment(userIban, taxAmount, taxType, taxNo))
                    {
                        MessageLabel.Text = "Vergi ödeme işlemi başarılı!";
                        MessageLabel.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        MessageLabel.Text = "Vergi ödeme işlemi sırasında bir hata oluştu.";
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
                MessageLabel.Text = "Lütfen geçerli bir tutar ve vergi numarası giriniz.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool CheckUserBalance(string iban, decimal amount)
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
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            decimal currentBalance = Convert.ToDecimal(result);
                            return currentBalance >= amount;
                        }
                        return result != null && Convert.ToDecimal(result) >= amount;
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

        private bool IsTaxAlreadyPaid(string taxNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Paid FROM Taxes WHERE TaxNo = @TaxNo";
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaxNo", taxNo);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            bool isPaid = Convert.ToBoolean(result);
                            return isPaid; 
                        }
                        return result != null && Convert.ToBoolean(result);
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

        private bool ProcessTaxPayment(string iban, decimal amount, string taxType, string taxNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deductQuery = "UPDATE Users SET Balance = Balance - @Amount WHERE IBAN = @IBAN";
                string updateTaxQuery = "UPDATE Taxes SET Paid = 1 WHERE TaxNo = @TaxNo";

                try
                {
                    connection.Open();

                    using (SqlCommand updateCommand = new SqlCommand(deductQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@IBAN", iban);
                        updateCommand.Parameters.AddWithValue("@Amount", amount);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            using (SqlCommand updateTaxCommand = new SqlCommand(updateTaxQuery, connection))
                            {
                                updateTaxCommand.Parameters.AddWithValue("@TaxNo", taxNo);
                                updateTaxCommand.ExecuteNonQuery();
                            }

                            RecordTaxPayment(iban, amount, taxType, taxNo);
                            return true;
                        }
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = "Veritabanı hatası: " + ex.Message;
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }
        }

        private void RecordTaxPayment(string iban, decimal amount, string taxType, string taxNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO TaxPayments (IBAN, Amount, TaxType, TaxNo, Date) VALUES (@IBAN, @Amount, @TaxType, @TaxNo, @Date)";
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IBAN", iban);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@TaxType", taxType);
                        command.Parameters.AddWithValue("@TaxNo", taxNo);
                        command.Parameters.AddWithValue("@Date", DateTime.Now);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = "Veritabanı hatası: " + ex.Message;
                }
            }
        }
    }
}
