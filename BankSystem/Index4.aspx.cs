using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BankSystem
{
    public partial class Index4 : System.Web.UI.Page
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

        protected void WithdrawButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text.Trim(), out decimal withdrawAmount))
            {
                if (withdrawAmount <= 0)
                {
                    MessageLabel.Text = "Tutar pozitif bir değer olmalıdır.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (withdrawAmount > 10000)
                {
                    MessageLabel.Text = "Maksimum çekim tutarı 10,000₺'dir.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string iban = Session["IBAN"].ToString(); 

                if (WithdrawAmount(iban, withdrawAmount))
                {
                    MessageLabel.Text = "Çekim işlemi başarılı!";
                    MessageLabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    MessageLabel.Text = "Çekim işlemi sırasında bir hata oluştu.";
                    MessageLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                MessageLabel.Text = "Lütfen geçerli bir tutar giriniz.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool WithdrawAmount(string iban, decimal withdrawAmount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string checkBalanceQuery = "SELECT Balance FROM Users WHERE IBAN = @IBAN";
                string updateBalanceQuery = "UPDATE Users SET Balance = Balance - @WithdrawAmount WHERE IBAN = @IBAN";

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

                        if (currentBalance < withdrawAmount)
                        {
                            MessageLabel.Text = "Yetersiz bakiye.";
                            MessageLabel.ForeColor = System.Drawing.Color.Red;
                            return false;
                        }
                    }

                    using (SqlCommand updateCommand = new SqlCommand(updateBalanceQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@IBAN", iban);
                        updateCommand.Parameters.AddWithValue("@WithdrawAmount", withdrawAmount);
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
