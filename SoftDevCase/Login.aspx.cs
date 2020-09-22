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
    public partial class Login : System.Web.UI.Page
    {
        BusinessLogic bl = new BusinessLogic();
        Encryption enc = new Encryption();
        DataAccess dac = new DataAccess();
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
                //string init_Pass = enc.EncryptToString("askbhgbasasbdfhkbasfjsbdfbhsbafbhabsdfbasybfsuadfsd");

                UserEnt userDetail = new UserEnt();

                userDetail.username = txtUsername.Text.Trim();
                userDetail.password = txtPassword.Text.Trim();

                if (bl.stringIsEmpty(userDetail.username) || bl.stringIsEmpty(userDetail.password))
                {
                    string ErrorMessage = "ERROR MESSAGE:  " + "GOT YOU!!!";
                    displayErrorMessage(ErrorMessage);
                }
                else
                {
                    userDetail.password = enc.EncryptToString(userDetail.password);

                    DataTable userDetails = dac.GetUserDetails(userDetail);
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