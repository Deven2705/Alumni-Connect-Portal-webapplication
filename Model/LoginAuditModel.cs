using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class LoginAuditModel
    {
        public string dbAction { get; set; }
        public string recordId { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string loginId { get; set; }
        public string ip { get; set; }
        public string userAgent { get; set; }
        public string role { get; set; }
    }
}