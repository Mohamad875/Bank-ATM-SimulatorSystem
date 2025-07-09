using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankSystem
{
    public partial class Index10 : System.Web.UI.Page
    {
        
        string connectionString = "Server=localhost;Database=BankSystem;User Id=sa;Password=sa123456;";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string fullName = NameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string iban = IBANTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(iban) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phone))
            {
                ErrorMessageLabel.Text = "Lütfen tüm alanları doldurunuz.";
                return;
            }

            
            if (IBANExists(iban))
            {
                ErrorMessageLabel.Text = "Bu IBAN zaten kayıtlı.";
                return;
            }

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (FullName, Email, IBAN, Password, Phone, Balance) " +
                               "VALUES (@FullName, @Email, @IBAN, @Password, @Phone, @Balance)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@IBAN", iban);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Balance", 0); 

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    ErrorMessageLabel.ForeColor = System.Drawing.Color.Green;
                    ErrorMessageLabel.Text = "Kayıt başarılı! Giriş yapabilirsiniz.";
                }
                catch (Exception ex)
                {
                    ErrorMessageLabel.Text = "Bir hata oluştu: " + ex.Message;
                }
            }
        }

        private bool IBANExists(string iban)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE IBAN = @IBAN";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IBAN", iban);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}