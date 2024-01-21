using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AlumniConnect.Model.OpeningModel;

namespace AlumniConnect
{
    public partial class ViewOpenings : System.Web.UI.Page
    {
        public List<OpeningModelRes> lstOpenings;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetOpeningList();
            }
        }

        private void GetOpeningList()
        {
            OpeningListRes res = new OpeningListRes();

            OpeningModelReq req = new OpeningModelReq();
            res = BAL.Openings.GetOpeningList(req);

            if(res.errorFlag == "N")
            {
                lstOpenings = res.lstOpenings;
            }
            

           //return res;
        }
    }
}