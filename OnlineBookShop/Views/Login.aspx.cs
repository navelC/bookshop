using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new Models.Functions();

        }
        public static string UserName = "";
        public static int User;
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Value == "" || txtPassword.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else if (txtUserName.Value == "Admin@gmail.com" && txtPassword.Value == "Password")
                {
                    Response.Redirect("Admin/Books.aspx");
                }
                else
                {
                    string Query = "Select * from SellerTbl where SellerEmail = '{0}' and SellerPassword = '{1}'";
                    Query = string.Format(Query, txtUserName.Value, txtPassword.Value);
                    DataTable dt = conn.GetData(Query);
                    if (dt.Rows.Count == 0)
                    {
                        Response.Redirect("Admin/Books.aspx");
                    }
                    else
                    {
                        UserName = txtUserName.Value;
                        User = Convert.ToInt32(dt.Rows[0][0].ToString());
                        Response.Redirect("Seller/Selling.aspx");

                    }
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;

            }
        }
    }
}