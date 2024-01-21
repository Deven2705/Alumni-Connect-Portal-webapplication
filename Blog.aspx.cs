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
    public partial class Blog : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BlogModel req = new BlogModel();    
            ErrorRes res = new ErrorRes();


            req.title = txtTitle.Text;
            req.description = txtDescription.Text;

            if (string.IsNullOrEmpty(Convert.ToString(req.title).Trim()))
            {

                lblMsg.Text = "Invalid Type";
                lblMsg.ForeColor = Color.Red;
            }

            else if (string.IsNullOrEmpty(Convert.ToString(req.description).Trim()))
            {
                lblMsg.Text = "Invalid description";
                lblMsg.ForeColor = Color.Red;
            }
            else
            {

                res = BAL.Blogs.AddBlog(req);
                if (res.errorFlag == "N")
                {

                    lblMsg.Text = res.errorMsg;
                    lblMsg.ForeColor = Color.Green;
                    //after sending values ,page should be reset
                    txtTitle.Text = "";
                    txtDescription.Text = "";

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