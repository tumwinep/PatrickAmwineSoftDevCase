using SoftDevCase.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SoftDevCase
{
    public partial class UploadSalesCsv : System.Web.UI.Page
    {
        BusinessLogic bl = new BusinessLogic();
        Encryption enc = new Encryption();


        string ErrorMessage, successMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager sh = new SessionManager();
            if (!sh.validSessionExists())
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                if (fileUpl.HasFile)
                {
                    string[] allowed = { ".csv" };

                    var extension = System.IO.Path.GetExtension(fileUpl.FileName);

                    bool validContentType = (fileUpl.PostedFile.ContentType == "application/vnd.ms-excel") || (fileUpl.PostedFile.ContentType == "text/plain") || (fileUpl.PostedFile.ContentType == "text/x-csv") ? true : false;

                    if (allowed.Contains(extension) && validContentType)
                    {
                        var fileSavePath = Server.MapPath("~/uploads/" + fileUpl.FileName);
                        fileUpl.SaveAs(fileSavePath);

                        string validFileInput = FileReader.ValidateUploadedFileData(fileSavePath);

                        if (validFileInput == "OK")
                        {
                            DataTable uplrecords = FileReader.GetDataFromUploadedFile(fileSavePath, Session["username"].ToString());

                            string result = bl.InsertLoadedDatatoDB(uplrecords);

                            if (result == "OK")
                            {
                                string procFilePath = Server.MapPath("~/uploads/Processed/" + fileUpl.FileName);
                                File.Move(fileSavePath, procFilePath);
                                successMessage = "FILE UPLOADED SUCCESSFULLY";
                                displayStatusMessage(successMessage, "SUCC");
                            }
                            else
                            {
                                File.Delete(fileSavePath);
                                ErrorMessage = result;
                                displayStatusMessage(ErrorMessage, "FAIL");
                            }
                        }
                        else
                        {
                            File.Delete(fileSavePath);
                            ErrorMessage = validFileInput;
                            displayStatusMessage(ErrorMessage, "FAIL");
                        }

                    }
                    else
                    {
                        ErrorMessage = bl.getErrorMessageDescription("E00004");
                        displayStatusMessage(ErrorMessage, "FAIL");
                    }
                }
                else
                {
                    ErrorMessage = bl.getErrorMessageDescription("E00003");
                    displayStatusMessage(ErrorMessage, "FAIL");
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
                        Label msgS = (Label)Master.FindControl("lblSuccessMessage");
                        msgS.Text = statusMessage;
                        msgS.Visible = true;
                        break;
                    case "FAIL":
                        Label msgF = (Label)Master.FindControl("lblErrorMessage");
                        msgF.Text = statusMessage;
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