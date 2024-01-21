using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumniConnect
{
    public partial class BlogDescription : System.Web.UI.Page
    {
        public List<BlogListModel> lstBlogs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["recordId"])))
                {
                    GetBlogList(Convert.ToString(Request.QueryString["recordId"]));
                }
                else
                {
                    Response.Redirect("ViewBlog.aspx");
                }
            }
        }

        private void GetBlogList(string recordId)
        {
            BlogList res = new BlogList();

            BlogModel req = new BlogModel();

            req.recordId = recordId;

            res = BAL.Blogs.GetBlogByRecordId(req);

            if (res.errorFlag == "N")
            {
                lstBlogs = res.lstBlogs;
            }

            //return res;
        }
    }
}