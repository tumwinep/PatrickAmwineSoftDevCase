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
        

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager sh = new SessionManager();
            if (!sh.validSessionExists())
            {
                Response.Redirect("Login.aspx", false);
            }
        }
    }
}