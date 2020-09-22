using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SoftDevCase
{
    public class SessionManager : System.Web.UI.Page
    {
        public void initialiseSession(DataTable userDetails)
        {
            try
            {
                Session["ValidUserSession"] = "OKAY";
                Session["username"] = userDetails.Rows[0]["username"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean validSessionExists()
        {
            Boolean resp = false;
            try
            {
                if (Session["ValidUserSession"] != null && Session["ValidUserSession"].ToString() == "OKAY")
                {
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