using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AlumniConnect.Model.BroadcastModel;

namespace AlumniConnect
{
    public partial class AddBroadcast : System.Web.UI.Page
    {

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BroadcastModel req = new BroadcastModel();
            ErrorRes res = new ErrorRes();


            req.status = ddlstatus.SelectedValue;
            req.broadcastMsg = txtbroadcastMsg.Text;
            req.createdBy = Convert.ToString(Session["RECORD_ID"]);
            req.expiryDate = txtExpiry.Text;

            if (string.IsNullOrEmpty(Convert.ToString(req.status).Trim()))
            {

                lblMsg.Text = "Invalid status";
                lblMsg.ForeColor = Color.Red;
            }

            else if (string.IsNullOrEmpty(Convert.ToString(req.broadcastMsg).Trim()))
            {
                lblMsg.Text = "Invalid broadcastMsg";
                lblMsg.ForeColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(Convert.ToString(req.expiryDate).Trim()))
            {
                lblMsg.Text = "Invalid Expiry Date";
                lblMsg.ForeColor = Color.Red;
            }
            else
            {
                //if (Convert.ToString(Session["ROLE"]) == "ADMIN")
                //{

                //    req.createdBy = "ADMIN";
                //}
                res = BAL.Broadcast.AddBroadcast(req);
                if (res.errorFlag == "N")
                {

                    lblMsg.Text = res.errorMsg;
                    lblMsg.ForeColor = Color.Green;
                    //after sending values ,page should be reset
                    ddlstatus.SelectedValue = "";
                    txtbroadcastMsg.Text = "";

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
            if(Convert.ToString(Session["ROLE"]) != "ADMIN")
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}