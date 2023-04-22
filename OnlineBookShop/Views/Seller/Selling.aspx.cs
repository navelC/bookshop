using OnlineBookShop.Views.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineBookShop.Views.Seller
{
    public partial class Selling : System.Web.UI.Page
    {
        Models.Functions conn;
        int Seller = Login.User;
        string SellerName = Login.UserName;
        string strConnection = "Data Source=DESKTOP-I598B34\\MAYAO;Initial Catalog=BOOKSHOP_ASPDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new Models.Functions();
            if (!IsPostBack)
            {
                hi.Value = DateTime.Now.ToString("yyyy-MM-dd");

                ShowBooks();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                 {
                    new DataColumn("ID"),
                    new DataColumn("Book"),
                    new DataColumn("Price"),
                    new DataColumn("Quantity"),
                    new DataColumn("Total")
                 }
                 );
                ViewState["Bill"] = dt;
                this.BindGrid();

                try {
                    SqlConnection con = new SqlConnection(strConnection);
                    string com = "Select * from BranchTbl";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                    adpt.Fill(dt);
                    ddlBranch.DataSource = dt;
                    ddlBranch.DataBind();
                    ddlBranch.DataTextField = "BrName";
                    ddlBranch.DataValueField = "BrId";
                    ddlBranch.DataBind();
                } catch (Exception Ex) {
                    Label2.Text = Ex.Message;
                }
            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            try {
                string Query = "  Select Bid as Code, BName as Name, BQty as Stock, BPrice as Price from BookTbl where BBranch = '" + ddlBranch.SelectedValue + "'";
                grvBooksList.DataSource = conn.GetData(Query);
                grvBooksList.DataBind();
                Label2.Text = "record found";
            }
            catch (Exception Ex)
            {
                Label2.Text = Ex.Message;
            }
        }
        protected void BindGrid()
        {
            grvBillsList.DataSource = ViewState["Bill"];
            grvBillsList.DataBind();
        }
        private void ShowBooks()
        {
            string Query = "  Select Bid as Code, BName as Name, BQty as Stock, BPrice as Price from BookTbl";
            grvBooksList.DataSource = conn.GetData(Query);
            grvBooksList.DataBind();
        }

        int Key = 0;
        int Stock = 0;
        protected void grvBooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBName.Value = grvBooksList.SelectedRow.Cells[2].Text;
            Stock = Convert.ToInt32(grvBooksList.SelectedRow.Cells[3].Text);
            txtBPrice.Value = grvBooksList.SelectedRow.Cells[4].Text;

            if (txtBName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(grvBooksList.SelectedRow.Cells[1].Text);
            }
        }
        private void UpdateStock()
        {
            int NewQty;
            NewQty = Convert.ToInt32(grvBooksList.SelectedRow.Cells[3].Text) - Convert.ToInt32(txtBQty.Value);

            string Query = "Update BookTbl set BQty = '{0}' where BId = '{1}'";
            Query = string.Format(Query, NewQty, grvBooksList.SelectedRow.Cells[1].Text);
            conn.SetData(Query);
            ShowBooks();
        }
        private void ShowBill()
        {
            string Query = "  Select * from BillTbl";
            grvBillsList.DataSource = conn.GetData(Query);
            grvBillsList.DataBind();
        }
        private void InsertBill()
        {
            
            try
            {
                string Query = "Insert into BillTbl values('{0}','{1}','{2}')";
                Query = string.Format(Query, hi.Value, Seller, Convert.ToInt32(txtGridTotal.Text.Substring(2)));
                conn.SetData(Query);
                //ShowBill();
            }
            catch(Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        int GridTotal = 0;
        int Amount;
        protected void btnAddToBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBName.Value == "" || txtBPrice.Value == "" || txtBQty.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else if (Convert.ToInt32(txtBQty.Value) >= Convert.ToInt32(grvBooksList.SelectedRow.Cells[3].Text))
                {
                    ErrMsg.Text = "Quantity >= Stock!!! Please insert another value";
                }
                else
                {
                    int total = Convert.ToInt32(txtBQty.Value) * Convert.ToInt32(txtBPrice.Value);
                    DataTable dt = (DataTable)ViewState["Bill"];
                    dt.Rows.Add(grvBillsList.Rows.Count + 1,
                        txtBName.Value.Trim(),
                        txtBPrice.Value.Trim(),
                        txtBQty.Value.Trim(),
                        total);
                    ViewState["Bill"] = dt;
                    this.BindGrid();
                    UpdateStock();

                    if (grvBillsList.Rows.Count < 2)
                    {
                        txtGridTotal.Text = "Rs " + Convert.ToInt32(grvBillsList.Rows[0].Cells[4].Text);
                    }
                    else
                    {
                        for (int i = 0; i < grvBillsList.Rows.Count; i++)
                        {
                            GridTotal = GridTotal + Convert.ToInt32(grvBillsList.Rows[i].Cells[4].Text);
                        }
                        txtGridTotal.Text = "Rs " + GridTotal;
                    }
                    Amount = GridTotal;

                    txtBName.Value = "";
                    txtBPrice.Value = "";
                    txtBQty.Value = "";
                    GridTotal = 0;
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            InsertBill();
        }
    }
}