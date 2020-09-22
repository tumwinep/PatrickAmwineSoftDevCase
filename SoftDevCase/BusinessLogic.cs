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
    }
}