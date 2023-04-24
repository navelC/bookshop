using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        Models.Functions conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new Models.Functions();
            if (!IsPostBack)
            {
                ShowBooks();
                GetAuthors();
                GetCategories();
                Getbranches();
            }
        }
        private void ShowBooks()
        {
            string Query = "  Select * from BookTbl";
            grvBooksList.DataSource = conn.GetData(Query);
            grvBooksList.DataBind();
        }
        private void GetAuthors()
        {
            string Query = "Select * from AuthorTbl";
            ddlBAuthors.DataTextField = conn.GetData(Query).Columns["AutName"].ToString();
            ddlBAuthors.DataValueField = conn.GetData(Query).Columns["AutId"].ToString();
            ddlBAuthors.DataSource = conn.GetData(Query);
            ddlBAuthors.DataBind();

        }
        private void Getbranches()
        {
            string Query = "Select * from BranchTbl";
            ddlBbranches.DataTextField = conn.GetData(Query).Columns["BrName"].ToString();
            ddlBbranches.DataValueField = conn.GetData(Query).Columns["BrId"].ToString();
            ddlBbranches.DataSource = conn.GetData(Query);
            ddlBbranches.DataBind();

        }
        private void GetCategories()
        {
            string Query = "Select * from CategoryTbl";
            ddlBCategories.DataTextField = conn.GetData(Query).Columns["CatName"].ToString();
            ddlBCategories.DataValueField = conn.GetData(Query).Columns["CatID"].ToString();
            ddlBCategories.DataSource = conn.GetData(Query);
            ddlBCategories.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitle.Value == "" || ddlBAuthors.SelectedIndex == -1 || ddlBCategories.SelectedIndex == -1 || txtQty.Value == ""
                    
                    || txtPrice.Value == "" )
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string BName = txtTitle.Value;
                    string BAuthors = ddlBAuthors.SelectedValue.ToString();
                    string BCategories = ddlBCategories.SelectedValue.ToString();
                    string BBbranches = ddlBbranches.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(txtQty.Value);
                    int Price = Convert.ToInt32(txtPrice.Value);

                    string Query = "Insert into BookTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, BName, BAuthors, BCategories, Quantity, Price, BBbranches);
                    conn.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book ADDED!!!";
                    txtTitle.Value = "";
                    ddlBAuthors.SelectedIndex = -1;
                    ddlBCategories.SelectedIndex = -1;
                    txtPrice.Value = "";
                    txtQty.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitle.Value == "" || ddlBAuthors.SelectedIndex == -1 || ddlBCategories.SelectedIndex == -1 || txtQty.Value == ""

                    || txtPrice.Value == "")
                {
                    ErrMsg.Text = "Select a Book!!!";
                }
                else
                {
                    string BName = txtTitle.Value;
                    string BAuthors = ddlBAuthors.SelectedValue.ToString();
                    string BCategories = ddlBCategories.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(txtQty.Value);
                    int Price = Convert.ToInt32(txtPrice.Value);

                    string Query = "Update BookTbl set BName = '{0}', BAuthor = '{1}', BCategory = '{2}', BQty = '{3}', BPrice = '{4}' where BId = '{5}'";
                    Query = string.Format(Query, BName, BAuthors, BCategories, Quantity, Price, grvBooksList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book UPDATED!!!";
                    txtTitle.Value = "";
                    ddlBAuthors.SelectedIndex = -1;
                    ddlBCategories.SelectedIndex = -1;
                    txtPrice.Value = "";
                    txtQty.Value = "";
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
                if (txtTitle.Value == "" || ddlBAuthors.SelectedIndex == -1 || ddlBCategories.SelectedIndex == -1 || txtQty.Value == ""

                    || txtPrice.Value == "")
                {
                    ErrMsg.Text = "Select a Book!!!";
                }
                else
                {
                    string BName = txtTitle.Value;
                    string BAuthors = ddlBAuthors.SelectedValue.ToString();
                    string BCategories = ddlBCategories.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(txtQty.Value);
                    int Price = Convert.ToInt32(txtPrice.Value);

                    string Query = "delete from BookTbl where BId = '{0}'";
                    Query = string.Format(Query, grvBooksList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book DELETED!!!";
                    txtTitle.Value = "";
                    ddlBAuthors.SelectedIndex = -1;
                    ddlBCategories.SelectedIndex = -1;
                    txtPrice.Value = "";
                    txtQty.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }
        int Key = 0;
        protected void grvBooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTitle.Value = grvBooksList.SelectedRow.Cells[2].Text;
            ddlBAuthors.SelectedIndex = ddlBAuthors.Items.IndexOf(ddlBAuthors.Items.FindByValue(grvBooksList.SelectedRow.Cells[3].Text));
            ddlBCategories.SelectedIndex = ddlBCategories.Items.IndexOf(ddlBCategories.Items.FindByValue(grvBooksList.SelectedRow.Cells[4].Text));
            txtQty.Value = grvBooksList.SelectedRow.Cells[5].Text;
            txtPrice.Value = grvBooksList.SelectedRow.Cells[6].Text;

            if (txtTitle.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(grvBooksList.SelectedRow.Cells[1].Text);
            }
        }
    }
}