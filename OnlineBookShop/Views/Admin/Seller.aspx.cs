using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        Models.Functions conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new Models.Functions();
            ShowSellers();

        }
        private void ShowSellers()
        {
            string Query = "Select * from SellerTbl";
            grvSellersList.DataSource = conn.GetData(Query);
            grvSellersList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSName.Value == "" || txtEmail.Value == "" || txtPhone.Value == "" || txtPassword.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string SellerName = txtSName.Value;
                    string Email = txtEmail.Value;
                    string Phone = txtPhone.Value;
                    string Password = txtPassword.Value;

                    string Query = "Insert into SellerTbl values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, SellerName, Email, Phone, Password);
                    conn.SetData(Query);
                    ShowSellers();
                    ErrMsg.Text = "Seller INSERTED!!!";
                    txtSName.Value = "";
                    txtEmail.Value = "";
                    txtPhone.Value = "";
                    txtPassword.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;
        protected void grvSellersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSName.Value = grvSellersList.SelectedRow.Cells[2].Text;
            txtEmail.Value = grvSellersList.SelectedRow.Cells[3].Text;
            txtPhone.Value = grvSellersList.SelectedRow.Cells[4].Text;
            txtPassword.Value = grvSellersList.SelectedRow.Cells[5].Text;


            if (txtSName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(grvSellersList.SelectedRow.Cells[1].Text);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSName.Value == "" || txtEmail.Value == "" || txtPhone.Value == "" || txtPassword.Value == "")
                {
                    ErrMsg.Text = "Select a Seller!!!";
                }
                else
                {
                    string SellerName = txtSName.Value;
                    string Email = txtEmail.Value;
                    string Phone = txtPhone.Value;
                    string Password = txtPassword.Value;

                    string Query = "Update SellerTbl set SellerName = '{0}', SellerEmail = '{1}', SellerPhone = '{2}', SellerPassword = '{3}' where SellerId = '{4}'";
                    Query = string.Format(Query, SellerName, Email, Phone, Password, grvSellersList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowSellers();
                    ErrMsg.Text = "Seller UPDATED!!!";
                    txtSName.Value = "";
                    txtEmail.Value = "";
                    txtPhone.Value = "";
                    txtPassword.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSName.Value == "" || txtEmail.Value == "" || txtPhone.Value == "" || txtPassword.Value == "")
                {
                    ErrMsg.Text = "Select a Seller!!!";
                }
                else
                {
                    string SellerName = txtSName.Value;
                    string Email = txtEmail.Value;
                    string Phone = txtPhone.Value;
                    string Password = txtPassword.Value;

                    string Query = "delete from SellerTbl where SellerId = '{0}'";
                    Query = string.Format(Query, grvSellersList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowSellers();
                    ErrMsg.Text = "Seller DELETE!!!";
                    txtSName.Value = "";
                    txtEmail.Value = "";
                    txtPhone.Value = "";
                    txtPassword.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }
    }
}