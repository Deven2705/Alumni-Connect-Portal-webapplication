using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumniConnect
{
    public partial class ViewBraodcast : System.Web.UI.Page
    {
        public List<BroadcastModel> lstBroadcasts;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["ROLE"]) != "ADMIN")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                GetBroadcastList();
            }
        }        

        private void GetBroadcastList()
        {
            BroadcastResList res = new BroadcastResList();

            BlogModel req = new BlogModel();
            res = BAL.Broadcast.GetAllBroadCasts();

            if (res.errorFlag == "N")
            {
                lstBroadcasts = res.lst;
            }

            //return res;
        }

        protected void btnInactivate_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                //get the id here
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ErrorRes UpdateBroadcast(string recordId,string status)
        //public static ErrorRes UpdateBroadcast()
        {
            //string recordId="", status="";
            ErrorRes res = new ErrorRes();
            res.errorFlag = "Y";

            BroadcastModel req = new BroadcastModel();
            req.recordId = recordId;

            if(status == "Y")
            {
                req.status = "N";
            }
            else if (status=="N")
            {
                req.status = "Y";
            }
            else
            {
                res.errorMsg = "Status cannot be blank";
                return res;

            }

            res = BAL.Broadcast.UpdateBroadcast(req);

            return res;
        }
    }
}