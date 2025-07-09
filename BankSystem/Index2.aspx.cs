using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BankSystem
{
    public partial class Index2 : System.Web.UI.Page
    {
        static string connectionString = "Server=localhost;Database=BankSystem;User Id=sa;Password=sa123456;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IBAN"] != null)
                {
                    Response.Redirect("Index3.aspx");
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string iban = IBANTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (ValidateUser(iban, password))
            {
                Session["IBAN"] = iban;

                Response.Redirect("Index3.aspx");
            }
            else
            {
                ErrorMessageLabel.Text = "Invalid IBAN or Password. Please try again.";
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool ValidateUser(string iban, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE IBAN = @IBAN AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IBAN", iban);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        int userCount = (int)command.ExecuteScalar();
                        return userCount > 0; 
                    }
                    catch (Exception ex)
                    {
                        ErrorMessageLabel.Text = "An error occurred while connecting to the database.";
                        ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}


