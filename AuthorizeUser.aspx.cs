using AlumniConnect.BAL;
using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumniConnect
{
    public partial class AuthorizeUser : System.Web.UI.Page
    {
        public List<HeadList> lst = new List<HeadList>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RECORD_ID"] != null && Session["ROLE"] != null)
            {
                if (Convert.ToString(Session["ROLE"]) == "ADMIN")
                {
                    if (!IsPostBack)
                    {
                        
                        lst = BindStudentDetails();
                    }
                    if ((Convert.ToString(Request.QueryString["status"]) == "suc"))
                        {
                        lblMsg.Text = "User Authorize Successfully";
                        lblMsg.ForeColor = Color.Green;
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public List<HeadList> BindStudentDetails()
        {
            DataTable dt = new DataTable();

            HeadListRes res = new HeadListRes();
            FilterReq freq = new FilterReq();

            freq.dbAction = "GETAUTHZLIST";

            res = UserDetails.GetHeadList(freq);

            return res.lstUserList;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ErrorRes AuthUnauthUser(string recordId, string type)
        {

            ErrorRes res = new ErrorRes();
            if (Convert.ToString(HttpContext.Current.Session["ROLE"]) == "ADMIN")
            {
                UserMasterModel req = new UserMasterModel();
                req.loginId = Convert.ToString(HttpContext.Current.Session["RECORD_ID"]);
                req.recordId = recordId;
                req.dbAction = "AUTHORIZE_USER";

                res = UserDetails.AuthUnauthUser(req);
            }
            else
            {
                res.errorFlag = "Y";
                res.errorMsg = "Session Expired";
                res.errorCode = "SES000";
            }
            return res;
        }
    }
}