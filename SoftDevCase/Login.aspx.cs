using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SoftDevCase
{
    public partial class Login : System.Web.UI.Page
    {
        BusinessLogic bl = new BusinessLogic();
        Encryption enc = new Encryption();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ValidUserSession"] == null || Session["ValidUserSession"].ToString() != "OKAY")
            //{
            //    Response.Redirect("Login.aspx", false);
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string init_Pass = enc.EncryptToString("askbhgbasasbdfhkbasfjsbdfbhsbafbhabsdfbasybfsuadfsd");
                string v_username = txtUsername.Text.Trim();
                string v_password = txtPassword.Text.Trim();

                if (bl.stringIsEmpty(v_username) || bl.stringIsEmpty(v_password))
                {
                    string ErrorMessage = "ERROR MESSAGE:  " + "GOT YOU!!!";
                    displayErrorMessage(ErrorMessage);

                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = ex.Message.ToString();
                displayErrorMessage(ErrorMessage);
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