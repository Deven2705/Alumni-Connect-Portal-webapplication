using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class HeaderValueModel : ErrorRes
    {
        public string name { get; set; }
        public bool role { get; set; }
        public string lastlogin { get; set; }
        public string headerImg { get; set; }
        public string location { get; set; }
        public string gender { get; set; }
        public string admissionYear { get; set; }
        public string passoutYear { get; set; }
        public string branch { get; set; }
        public string totFamilies { get; set; }
        public string totMembers { get; set; }
        public string totLoggedIn { get; set; }
    }

    public class HeadListRes : ErrorRes
    {
        public List<HeadList> lstUserList { get; set; }
    }

    public class HeaderValueReq : ErrorRes
    {
        public string dbAction { get; set; }
    }

    public class HeadList
    {
        public string recordId { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string location { get; set; }
        public string companyName { get; set; }
        public string designation { get; set; }
        public string admissionYear { get; set; }
        public string passoutYear { get; set; }
        public string branch { get; set; }
        public string imgUrl { get; set; }
        public string fb { get; set; }
        public string gmail { get; set; }
        public string linkedIn { get; set; }
    }
}