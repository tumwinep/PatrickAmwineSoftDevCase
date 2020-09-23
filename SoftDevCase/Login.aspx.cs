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

                //string ewr = enc.EncryptToString("admin@123");

                userDetail.username = txtUsername.Text.Trim();
                userDetail.password = txtPassword.Text.Trim();

                if (bl.stringIsEmpty(userDetail.username) || bl.stringIsEmpty(userDetail.password))
                {
                    ErrorMessage = bl.getErrorMessageDescription("E00001");
                    displayStatusMessage(ErrorMessage, "FAIL");
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
                        displayStatusMessage(ErrorMessage, "FAIL");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                displayStatusMessage(ErrorMessage, "FAIL");
            }
        }

        private void displayStatusMessage(string statusMessage, string type)
        {
            try
            {
                switch (type)
                {
                    case "SUCC":
                        Label msgFa = (Label)Master.FindControl("lblErrorMessage");
                        Label msgS = (Label)Master.FindControl("lblSuccessMessage");
                        msgFa.Visible = false;
                        msgS.Text = statusMessage;
                        msgS.Visible = true;
                        break;
                    case "FAIL":
                        Label msgF = (Label)Master.FindControl("lblErrorMessage");
                        Label msgSuc = (Label)Master.FindControl("lblSuccessMessage");
                        msgF.Text = statusMessage;
                        msgSuc.Visible = false;
                        msgF.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                //Log Error some other way and Ignore Further Action. Will return to this later
            }
        }
    }
}