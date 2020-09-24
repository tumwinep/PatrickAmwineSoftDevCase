using SoftDevCase.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftDevCase
{
    public class BusinessLogic : System.Web.UI.Page
    {
        DataAccess dac = new DataAccess();
        
        public Boolean stringIsEmpty(string stringToTest)
        {
            try
            {
                if (stringToTest is null || stringToTest.Trim().Equals(""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean validCredentials(UserEnt userDetail)
        {
            Boolean resp = false;
            try
            {
                DataTable userDetails = dac.GetUserDetails(userDetail);
                if (userDetails.Rows.Count > 0)
                {
                    SessionManager sh = new SessionManager();
                    sh.initialiseSession(userDetails);
                    resp = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public DataTable GetSalesRecordsData()
        {
            DataTable resp = new DataTable();
            try
            {
                resp = dac.GetSalesRecordsData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public string getErrorMessageDescription(string errorCode)
        {
            string resp = "";
            try
            {
                DataTable ErrorDetail = dac.GetErrorCodeDescription(errorCode);
                if (ErrorDetail.Rows.Count > 0)
                {
                    resp = ErrorDetail.Rows[0]["errorDesc"].ToString().ToUpper();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public string InsertLoadedDatatoDB(DataTable uplrecords)
        {
            string resp = "";
            try
            {
                resp = dac.InsertLoadedDatatoDB(uplrecords);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public string validateSelectedDates(string selectFromDate, string selectToDate)
        {
            string resp = "OK";
            try
            {
                if (!selectToDate.Trim().Equals("") && !selectFromDate.Trim().Equals(""))
                {
                    if (Convert.ToDateTime(selectToDate) < Convert.ToDateTime(selectFromDate))
                    {
                        resp = "'FROM DATE' MUST BE EARLIER THAN THE 'TO DATE'";
                    }
                    else
                    {
                        DateTime temp;
                        if (DateTime.TryParseExact(selectFromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                        {
                            if (!DateTime.TryParseExact(selectToDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                            {
                                resp = "INVALID 'TO DATE' SUPPLIED";
                            }
                        }
                        else
                        {
                            resp = "INVALID 'FROM DATE' SUPPLIED";
                        }
                    }
                }
                else
                {
                    resp = "DATE SELECTION CANNOT BE EMPTY";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public DataTable gisplayProftDetailsGrid(string selectFromDate, string selectToDate)
        {
            DataTable resp = new DataTable();
            try
            {
                resp = dac.gisplayProftDetailsGrid(selectFromDate, selectToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public DataTable gisplayProftItemsGrid(string selectFromDate, string selectToDate)
        {
            DataTable resp = new DataTable();
            try
            {
                resp = dac.gisplayProftItemsGrid(selectFromDate, selectToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public string returnDBFormatedDate(string dateToFormat)
        {
            string resp = "";
            try
            {
                DateTime fromDate = DateTime.ParseExact(dateToFormat, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                resp = fromDate.ToString("yyyy/MM/dd");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public string CalculateTotalProfit(DataTable profitDetails)
        {
            string resp = "";
            Double totalProfit = 0;
            try
            {
                foreach (DataRow dtRow in profitDetails.Rows)
                {
                    string rowProfit = dtRow["Total_Profit"].ToString();
                    totalProfit += Convert.ToDouble(rowProfit);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            string formatedText = string.Format("{0:0,0.00}", totalProfit); 
            return formatedText;
        }
    }
}