using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class LoginModel : ErrorRes
    {
        public string dbAction { get; set; }
        public string loginId { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string authorized { get; set; }
        public string authorizedBy { get; set; }
        public string captcha { get; set; }
        public string otp { get; set; }
        public string ip { get; set; }
        public string role { get; set; }
    }

    public class LoginRes : ErrorRes
    {
        public string loginId { get; set; }
        public string email { get; set; }
    }
}