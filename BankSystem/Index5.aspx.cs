using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace BankSystem
{
    public partial class Index5 : System.Web.UI.Page
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

        protected void DepositButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text.Trim(), out decimal depositAmount))
            {
                if (depositAmount <= 0)
                {
                    MessageLabel.Text = "Tutar pozitif bir değer olmalıdır.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (depositAmount > 100000)
                {
                    MessageLabel.Text = "Maksimum yatırma tutarı 100,000₺'dir.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string iban = Session["IBAN"].ToString(); 

                if (DepositAmount(iban, depositAmount))
                {
                    MessageLabel.Text = "Yatırma işlemi başarılı!";
                    MessageLabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    MessageLabel.Text = "Yatırma işlemi sırasında bir hata oluştu.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                MessageLabel.Text = "Lütfen geçerli bir tutar giriniz.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool DepositAmount(string iban, decimal depositAmount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string checkBalanceQuery = "SELECT Balance FROM Users WHERE IBAN = @IBAN";
                string updateBalanceQuery = "UPDATE Users SET Balance = Balance + @DepositAmount WHERE IBAN = @IBAN";

                try
                {
                    connection.Open();

                    using (SqlCommand checkCommand = new SqlCommand(checkBalanceQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@IBAN", iban);
                        object balanceObj = checkCommand.ExecuteScalar();

                        if (balanceObj == null || balanceObj == DBNull.Value)
                        {
                            MessageLabel.Text = "Kullanıcı bulunamadı.";
                            MessageLabel.ForeColor = System.Drawing.Color.Red;
                            return false;
                        }

                        decimal currentBalance = Convert.ToDecimal(balanceObj);
                    }

                    using (SqlCommand updateCommand = new SqlCommand(updateBalanceQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@IBAN", iban);
                        updateCommand.Parameters.AddWithValue("@DepositAmount", depositAmount);
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        return rowsAffected > 0;
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
