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
    public partial class UserLogOut : System.Web.UI.Page
    {
        BusinessLogic bl = new BusinessLogic();
        Encryption enc = new Encryption();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager sh = new SessionManager();
            sh.destroySession();
            Response.Redirect("Login.aspx");
        }
    }
}