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

        string ErrorMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                UserEnt userDetail = new UserEnt();

                userDetail.username = txtUsername.Text.Trim();
                userDetail.password = txtPassword.Text.Trim();

                if (bl.stringIsEmpty(userDetail.username) || bl.stringIsEmpty(userDetail.password))
                {
                    ErrorMessage = bl.getErrorMessageDescription("E00001");
                    displayErrorMessage(ErrorMessage);
                }
                else
                {
                    userDetail.password = enc.EncryptToString(userDetail.password);
                    Boolean validCredentials = bl.validCredentials(userDetail);
                    if (validCredentials)
                    {
                        Response.Redirect("Landing.aspx", false);
                    }
                    else
                    {
                        ErrorMessage = bl.getErrorMessageDescription("E00002");
                        displayErrorMessage(ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
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