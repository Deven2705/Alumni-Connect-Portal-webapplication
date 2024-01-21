using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class ErrorLogModel
    {
        public string dbActionMode { get; set; }
        public string loginId { get; set; }
        public string appName { get; set; }
        public string apiName { get; set; }
        public string browser { get; set; }
        public string request { get; set; }
        public string response { get; set; }
        public string errorDesc { get; set; }
        public string logType { get; set; }
        public DateTime? createdDate { get; set; }
    }
}