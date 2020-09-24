using SoftDevCase.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SoftDevCase
{
    public partial class Dashboard : System.Web.UI.Page
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

        }
        protected void lnbtn_pickDate_click(object sender, EventArgs e)
        {
            try
            {
                cldr_fromDate.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }


        protected void lnbtn_pickDateTo_click(object sender, EventArgs e)
        {
            try
            {
                cldr_toDate.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }

        protected void cldr_fromDate_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_fromdatepicker.Text = cldr_fromDate.SelectedDate.ToShortDateString();
                cldr_fromDate.Visible = false;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }

        protected void cldr_toDate_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_todatepicker.Text = cldr_toDate.SelectedDate.ToShortDateString();
                cldr_toDate.Visible = false;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }


        protected void indexChangedTotprofit(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string selectFromDate = txt_fromdatepicker.Text.Trim();
                string selectToDate = txt_todatepicker.Text.Trim();

                string validateDateResponse = bl.validateSelectedDates(selectFromDate, selectToDate);

                if (validateDateResponse == "OK")
                {
                    string fromDateFormated = bl.returnDBFormatedDate(selectFromDate);
                    string toDateFormated = bl.returnDBFormatedDate(selectToDate);
                    gv_totprofitDetail.PageIndex = e.NewPageIndex;
                    DisplayGrids(selectFromDate, selectToDate);
                }
                else
                {
                    ErrorMessage = validateDateResponse;
                    displayStatusMessage(ErrorMessage, "FAIL");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }


        }

        protected void indexChangedTopItems(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string selectFromDate = txt_fromdatepicker.Text.Trim();
                string selectToDate = txt_todatepicker.Text.Trim();

                string validateDateResponse = bl.validateSelectedDates(selectFromDate, selectToDate);

                if (validateDateResponse == "OK")
                {
                    string fromDateFormated = bl.returnDBFormatedDate(selectFromDate);
                    string toDateFormated = bl.returnDBFormatedDate(selectToDate);
                    gv_topItems.PageIndex = e.NewPageIndex;
                    DisplayProfitableItemsGrids(fromDateFormated, toDateFormated);
                }
                else
                {
                    ErrorMessage = validateDateResponse;
                    displayStatusMessage(ErrorMessage, "FAIL");
                }


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string selectFromDate = txt_fromdatepicker.Text.Trim();
                string selectToDate = txt_todatepicker.Text.Trim();

                string validateDateResponse = bl.validateSelectedDates(selectFromDate, selectToDate);

                if (validateDateResponse == "OK")
                {
                    string fromDateFormated = bl.returnDBFormatedDate(selectFromDate);
                    string toDateFormated = bl.returnDBFormatedDate(selectToDate);
                    DisplayGrids(fromDateFormated, toDateFormated);
                    DisplayProfitableItemsGrids(fromDateFormated, toDateFormated);
                }
                else
                {
                    ErrorMessage = validateDateResponse;
                    displayStatusMessage(ErrorMessage, "FAIL");
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }
        public void DisplayProfitableItemsGrids(string selectFromDate, string selectToDate)
        {
            try
            {
                DataTable profitItems = bl.gisplayProftItemsGrid(selectFromDate, selectToDate);
                gv_topItems.DataSource = profitItems;
                gv_topItems.DataBind();
                
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }

        public void DisplayGrids(string selectFromDate, string selectToDate)
        {
            try
            {
                DataTable profitDetails = bl.gisplayProftDetailsGrid(selectFromDate, selectToDate);
                gv_totprofitDetail.DataSource = profitDetails;
                gv_totprofitDetail.DataBind();

                displayTotalProfitMadeInfo(profitDetails);
                
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }

        private void displayTotalProfitMadeInfo(DataTable profitDetails)
        {
            try
            {
                string totalProfit = bl.CalculateTotalProfit(profitDetails);
                mv_dashboardDetails.Visible = true;
                lbltotProfitDisplay.Text = "TOTAL PROFIT MADE: " + totalProfit;

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
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