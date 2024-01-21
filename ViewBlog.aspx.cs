using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumniConnect
{
    public partial class ViewBlog : System.Web.UI.Page
    {
        public List<BlogListModel> lstBlogs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBlogList();
            }
        }

        private void GetBlogList()
        {
            BlogList res = new BlogList();

            BlogModel req = new BlogModel();
            res = BAL.Blogs.GetBlogList(req);

            if (res.errorFlag == "N")
            {
                lstBlogs = res.lstBlogs;
            }

            //return res;
        }
    }
}