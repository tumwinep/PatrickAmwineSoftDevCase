using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftDevCase
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                SessionManager sh = new SessionManager();
                sh.destroySession();
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
            }
        }
    }
}