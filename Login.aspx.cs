using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumniConnect
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] != null)
            {
                if (Convert.ToString(Request.QueryString["mode"]) == "sww")
                {
                    lblMsg.Text = "Something went wrong";
                    lblMsg.ForeColor = Color.Red;
                }
            }

            if (!IsPostBack)
            {
                if (Request.Cookies["userid"] != null)
                    txtUsername.Text = Request.Cookies["userid"].Value;
                if (Request.Cookies["pwd"] != null)
                    txtPassword.Attributes.Add("value", Request.Cookies["pwd"].Value);
                if (Request.Cookies["userid"] != null && Request.Cookies["pwd"] != null)
                    chkRemember.Checked = true;
            }

            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            LoginModel login = new LoginModel();

            login.email = username;
            login.password = password;
            login.ip = BAL.Login.GetIPAddress();

            if (chkRemember.Checked == true)
            {
                Response.Cookies["userid"].Value = txtUsername.Text;
                Response.Cookies["pwd"].Value = txtPassword.Text;
                Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
            }
            else
            {
                Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
            }

            BAL.Login.ValidateLogin(login);

            if(login.errorFlag == "N")
            {
                Session["RECORD_ID"] = login.recordId;
                Session["ROLE"] = login.role;

                Response.Redirect("Dashboard.aspx");

                lblMsg.Text = "Succesfully Login";
                lblMsg.ForeColor = Color.Green;
            }
            else
            {
                lblMsg.Text = login.errorMsg;
                lblMsg.ForeColor = Color.Red;
            }
            //if(username == "Deven" && password == "Deven@123")
            //{
            //    lblMsg.Text = "Succesfully Login";
            //    lblMsg.ForeColor = Color.Green;
            //}
            //else
            //{
            //    lblMsg.Text = "Invalid Login Credentials";
            //    lblMsg.ForeColor = Color.Red;
            //}
        }
    }
}
