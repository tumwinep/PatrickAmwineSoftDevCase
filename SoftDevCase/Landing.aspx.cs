using SoftDevCase.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SoftDevCase
{
    public partial class Landing : System.Web.UI.Page
    {
        BusinessLogic bl = new BusinessLogic();
        Encryption enc = new Encryption();
        

        string ErrorMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager sh = new SessionManager();
            if (!sh.validSessionExists())
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        

        private void displayErrorMessage(string errorMessage)
        {
            try
            {
                Label msg = (Label)Master.FindControl("lblErrorMessage");
                msg.Text = errorMessage;
                msg.Visible = true;
            }
            catch (Exception ex)
            {
                //Log Error some other way and Ignore Further Action. Will return to this later
            }
        }
    }
}