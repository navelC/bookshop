using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new Models.Functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            string Query = "Select * from CategoryTbl";
            grvCategoriesList.DataSource = conn.GetData(Query);
            grvCategoriesList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCatName.Value == "" || txtDescription.Value=="")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string CatName = txtCatName.Value;
                    string CatDesc = txtDescription.Value;

                    string Query = "Insert into CategoryTbl values('{0}','{1}')";
                    Query = string.Format(Query, CatName, CatDesc);
                    conn.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "Category INSERTED!!!";
                    txtCatName.Value = "";
                    txtDescription.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;
        protected void grvCategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCatName.Value = grvCategoriesList.SelectedRow.Cells[2].Text;
            txtDescription.Value = grvCategoriesList.SelectedRow.Cells[3].Text;

            if (txtCatName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(grvCategoriesList.SelectedRow.Cells[1].Text);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCatName.Value == "" || txtDescription.Value == "")
                {
                    ErrMsg.Text = "Select a Category!!!";
                }
                else
                {
                    string CatName = txtCatName.Value;
                    string CatDesc = txtDescription.Value;

                    string Query = "Update CategoryTbl set CatName = '{0}', CatDescription = '{1}' where CatID = '{2}'";
                    Query = string.Format(Query, CatName, CatDesc, grvCategoriesList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "Category UPDATED!!!";
                    txtCatName.Value = "";
                    txtDescription.Value = "";
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
                if (txtCatName.Value == "" || txtDescription.Value == "")
                {
                    ErrMsg.Text = "Select a Category!!!";
                }
                else
                {
                    string CatName = txtCatName.Value;
                    string CatDesc = txtDescription.Value;

                    string Query = "delete from CategoryTbl where CatID = '{0}'";
                    Query = string.Format(Query, grvCategoriesList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "Category DELETE!!!";
                    txtCatName.Value = "";
                    txtDescription.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }
    }
}