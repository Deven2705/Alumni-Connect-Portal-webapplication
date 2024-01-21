using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class EventModelReq : ErrorRes
    {
        public string dbAction { get; set; }
        public string title { get; set; }
        public string imgUrl { get; set; }
        public string description { get; set; }
        public string loginId { get; set; }
        public string eventDate { get; set; }
        public string active { get; set; }
        public string authzList { get; set; }
    }

    public class EventModel
    {
        public string imgUrl { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class EventListRes : ErrorRes
    {
        public List<EventModel> lstEvents { get; set; }
    }
}