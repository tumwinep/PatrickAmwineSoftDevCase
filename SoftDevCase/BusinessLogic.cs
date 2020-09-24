using SoftDevCase.Entity;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}