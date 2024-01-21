using AlumniConnect.BAL;
using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumniConnect
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public List<HeadList> lst = new List<HeadList>();

        public string strBroadcast = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["RECORD_ID"] != null)
            {
                if(!IsPostBack)
                {
                    lst = BindStudentDetails();
                    GetBroadcast();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void GetBroadcast()
        {
            BroadcastResList res = new BroadcastResList();
            List<BroadcastModel> lst = new List<BroadcastModel>();

            res = Broadcast.GetBroadCasts();

            if(res.errorFlag == "N")
            {
                lst = res.lst;
                if (lst != null)
                {
                    if (lst.Count > 0)
                    {
                        for (int i = 0; i < lst.Count; i++)
                        {
                            strBroadcast = strBroadcast + " | " + lst[i].broadcastMsg;
                        }
                    }
                }
            }
        }

        public List<HeadList> BindStudentDetails()
        {
            DataTable dt = new DataTable();

            HeadListRes res = new HeadListRes();
            FilterReq freq = new FilterReq();

            freq.dbAction = "SEARCH_DASHBOARD";

            //AUTHORIZE_USER

            res = UserDetails.GetHeadList(freq);

            return res.lstUserList;
        }

        
    }
}