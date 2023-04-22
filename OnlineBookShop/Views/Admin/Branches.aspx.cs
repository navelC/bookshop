using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Branches : System.Web.UI.Page
    {
        Models.Functions conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new Models.Functions();
            ShowBranches();
        }
        private void ShowBranches()
        {
            string Query = "Select * from BranchTbl";
            grvBranchesList.DataSource = conn.GetData(Query);
            grvBranchesList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBrName.Value == "" || txtLocation.Value == "")
                {
                    ErrMsg.Text = "Missing Data!!!";
                }
                else
                {
                    string BrName = txtBrName.Value;
                    string BrLocation = txtLocation.Value;

                    string Query = "Insert into BranchTbl values('{0}','{1}')";
                    Query = string.Format(Query, BrName, BrLocation);
                    conn.SetData(Query);
                    ShowBranches();
                    ErrMsg.Text = "Branch INSERTED!!!";
                    txtBrName.Value = "";
                    txtLocation.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;
        protected void grvBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBrName.Value = grvBranchesList.SelectedRow.Cells[2].Text;
            txtLocation.Value = grvBranchesList.SelectedRow.Cells[3].Text;

            if (txtBrName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(grvBranchesList.SelectedRow.Cells[1].Text);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBrName.Value == "" || txtLocation.Value == "")
                {
                    ErrMsg.Text = "Select a Branch!!!";
                }
                else
                {
                    string BrName = txtBrName.Value;
                    string BrLocation = txtLocation.Value;
    
                    string Query = "Update BranchTbl set BrName = '{0}', BrLocation = '{1}' where BrId = '{2}'";
                    Query = string.Format(Query, BrName, BrLocation, grvBranchesList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowBranches();
                    ErrMsg.Text = "Branch UPDATED!!!";
                    txtBrName.Value = "";
                    txtLocation.Value = "";
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
                if (txtBrName.Value == "" || txtLocation.Value == "")
                {
                    ErrMsg.Text = "Select a Branch!!!";
                }
                else
                {
                    string BrName = txtBrName.Value;
                    string BrLocation = txtLocation.Value;

                    string Query = "delete from BranchTbl where BrId = '{0}'";
                    Query = string.Format(Query, grvBranchesList.SelectedRow.Cells[1].Text);
                    conn.SetData(Query);
                    ShowBranches();
                    ErrMsg.Text = "Branch DELETE!!!";
                    txtBrName.Value = "";
                    txtLocation.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }
    }
}