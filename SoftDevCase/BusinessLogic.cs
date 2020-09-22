using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftDevCase
{
    public class BusinessLogic : System.Web.UI.Page
    {

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

        
    }
}