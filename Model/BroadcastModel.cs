using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class BroadcastModel:ErrorRes
    {
        public string dbAction { get; set; }
        public string broadcastMsg { get; set; }
        public string expiryDate { get; set; }
        public string status { get; set; }
        public string createdBy { get; set; }
    }

    public class BroadcastResList:ErrorRes
    {
        public List<BroadcastModel> lst { get; set; }
    }
}