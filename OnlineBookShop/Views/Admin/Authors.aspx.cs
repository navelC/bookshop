using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Authors : System.Web.UI.Page
    {
        Models.Functions conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new Models.Functions();
            ShowAuthors();
        }
        private void ShowAuthors()
        {
            string Query = "Select * from AuthorTbl";
            grvAuthorsList.DataSource = conn.GetData(Query);
            grvAuthorsList.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAuthorName.Value == "" || ddlGender.SelectedIndex == -1 || ddlCountry.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string AName = txtAuthorName.Value;
                    string Gender = ddlGender.SelectedItem.ToString();
                    string Country = ddlCountry.SelectedItem.ToString();

                    string Query = "Insert into AuthorTbl values('{0}','{1}','{2}')";
                    Query = string.Format(Query, AName, Gender, Country);
                    conn.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author INSERTED!!!";
                    txtAuthorName.Value = "";
                    ddlGender.SelectedIndex = -1;
                    ddlCountry.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }
        int Key = 0;
        protected void grvAuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAuthorName.Value = grvAuthorsList.SelectedRow.Cells[2].Text;
            ddlGender.SelectedIndex = ddlGender.Items.IndexOf(ddlGender.Items.FindByText(grvAuthorsList.SelectedRow.Cells[3].Text));
            ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText(grvAuthorsList.SelectedRow.Cells[4].Text));
            //ddlGender.SelectedItem.Value = grvAuthorsList.SelectedRow.Cells[3].Text;
            //ddlCountry.SelectedItem.Value = grvAuthorsList.SelectedRow.Cells[4].Text;
            if(txtAuthorName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(grvAuthorsList.SelectedRow.Cells[1].Text);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAuthorName.Value == "" || ddlGender.SelectedIndex == -1 || ddlCountry.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Select an Author!!!";
                }
                else
                {
                    string AName = txtAuthorName.Value;
                    string Gender = ddlGender.SelectedItem.ToString();
                    string Country = ddlCountry.SelectedItem.ToString();

                    string Query = "Update AuthorTbl set AutName = '{0}', AutGender = '{1}', AutCountry = '{2}' where AutId = '{3}'";
                    Query = string.Format(Query, AName, Gender, Country, grvAuthorsList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author UPDATED!!!";
                    txtAuthorName.Value = "";
                    ddlGender.SelectedIndex = -1;
                    ddlCountry.SelectedIndex = -1;
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
                if (txtAuthorName.Value == "" || ddlGender.SelectedIndex == -1 || ddlCountry.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Select an Author!!!";
                }
                else
                {
                    string AName = txtAuthorName.Value;
                    string Gender = ddlGender.SelectedItem.ToString();
                    string Country = ddlCountry.SelectedItem.ToString();

                    string Query = "delete from AuthorTbl where AutId = '{0}'";
                    Query = string.Format(Query, grvAuthorsList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author DELETED!!!";
                    txtAuthorName.Value = "";
                    ddlGender.SelectedIndex = -1;
                    ddlCountry.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }
    }
}