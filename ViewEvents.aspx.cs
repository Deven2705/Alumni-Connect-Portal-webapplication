using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumniConnect
{
    public partial class ViewEvents : System.Web.UI.Page
    {
        public List<EventModel> lstEvents;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEventList();
            }
        }

        private void GetEventList()
        {
            EventListRes res = new EventListRes();

            EventModel req = new EventModel();
            res = BAL.Events.GetEvents();

            if (res.errorFlag == "N")
            {
                lstEvents = res.lstEvents;
            }

            //return res;
        }
    }
}