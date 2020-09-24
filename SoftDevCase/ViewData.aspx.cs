using SoftDevCase.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SoftDevCase
{
    public partial class ViewData : System.Web.UI.Page
    {
        BusinessLogic bl = new BusinessLogic();
        Encryption enc = new Encryption();


        string ErrorMessage, successMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager sh = new SessionManager();
            if (!sh.validSessionExists())
            {
                Response.Redirect("Login.aspx", false);
            }
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                DataTable salesRecords = bl.GetSalesRecordsData();
                gv_salesRecords.DataSource = salesRecords;
                gv_salesRecords.DataBind();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }

        protected void indexChanged(object sender, GridViewPageEventArgs e)
        {
            gv_salesRecords.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        private void displayStatusMessage(string statusMessage, string type)
        {
            try
            {
                switch (type)
                {
                    case "SUCC":
                        Label msgFa = (Label)Master.FindControl("lblErrorMessage");
                        Label msgS = (Label)Master.FindControl("lblSuccessMessage");
                        msgFa.Visible = false;
                        msgS.Text = statusMessage;
                        msgS.Visible = true;
                        break;
                    case "FAIL":
                        Label msgF = (Label)Master.FindControl("lblErrorMessage");
                        Label msgSuc = (Label)Master.FindControl("lblSuccessMessage");
                        msgF.Text = statusMessage;
                        msgSuc.Visible = false;
                        msgF.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                //Log Error some other way and Ignore Further Action. Will return to this later
            }
        }
    }
}