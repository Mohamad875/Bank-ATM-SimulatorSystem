using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankSystem
{
    public partial class Index3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }




        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();  // إنهاء الجلسة
            Session.Clear();    // مسح جميع البيانات المخزنة في الجلسة
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-1); // حذف الكوكيز المرتبطة بالجلسة

            Response.Redirect("Index2.aspx");
        }
    }
}