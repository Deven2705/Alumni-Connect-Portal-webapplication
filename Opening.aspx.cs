using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AlumniConnect.Model.OpeningModel;

namespace AlumniConnect
{
    public partial class Opening : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OpeningModelReq req = new OpeningModelReq();
            ErrorRes res = new ErrorRes();

            req.title = txtTitle.Text;
            req.description = txtDescription.Text;
            req.resumeLink = txtSRT.Text;
            req.type = ddlType.SelectedValue;

            //    res = BAL.Openings.AddOpening(req);

            if (string.IsNullOrEmpty(Convert.ToString(req.type).Trim()))
            {
               
                lblMsg.Text = "Invalid Type";
                lblMsg.ForeColor = Color.Red;
            }

            else if (string.IsNullOrEmpty(Convert.ToString(req.description).Trim()))
            {
                lblMsg.Text = "Invalid description";
                lblMsg.ForeColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(Convert.ToString(req.resumeLink).Trim()))
            {
                lblMsg.Text = "Invalid Send Resume link";
                lblMsg.ForeColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(Convert.ToString(req.title).Trim()))
            {
                lblMsg.Text = "Invalid Title";
                lblMsg.ForeColor = Color.Red;
            }

            else
            {

                res = BAL.Openings.AddOpening(req);
                 if (res.errorFlag == "N")
                {

                    lblMsg.Text = res.errorMsg;
                    lblMsg.ForeColor = Color.Green;
                    //after sending values ,page should be reset
                    txtTitle.Text = "";
                    ddlType.SelectedValue = "";
                    txtDescription.Text="";
                    txtSRT.Text="";

                }
                else
                {
                    lblMsg.Text = res.errorMsg;
                    lblMsg.ForeColor = Color.Red;
                }
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}