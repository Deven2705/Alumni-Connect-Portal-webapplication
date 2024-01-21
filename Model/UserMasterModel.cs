using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class UserMasterModel : ErrorRes
    {
        public string dbAction { get; set; }
        public string mobileNo { get; set; }
        public string emailID { get; set; }
        public string name { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string nickName { get; set; }
        public string bloodGroup { get; set; }
        public string city { get; set; }
        public string nativePlace { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string branch { get; set; }
        public string admissionYear { get; set; }
        public string passoutYear { get; set; }
        public string hobbies { get; set; }
        public string companyName { get; set; }
        public string designation { get; set; }
        public string higherEducation { get; set; }
        public string bachelorDegree { get; set; }
        public string specialization { get; set; }
        public string imgUrl { get; set; }
        public string experience { get; set; }
        public string about { get; set; }
        public string loginId { get; set; }
        public string authzList { get; set; }
        public string linkedIn { get; set; }
        public string password { get; set; }
        public string bdayFlag { get; set; }
    }

    public class UserMasterRes
    {
        public string mobileNo { get; set; }
        public string emailId { get; set; }
        public string name { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string nickName { get; set; }
        public string bloodGroup { get; set; }
        public string city { get; set; }
        public string nativePlace { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string branch { get; set; }
        public string admissionYear { get; set; }
        public string passoutYear { get; set; }
        public string hobbies { get; set; }
        public string companyName { get; set; }
        public string designation { get; set; }
        public string higherEducation { get; set; }
        public string bachelorDegree { get; set; }
        public string specialization { get; set; }
        public string imgUrl { get; set; }
        public string experience { get; set; }
        public string about { get; set; }
        public string linkedIn { get; set; }
    }

    public class UserMasterList : ErrorRes
    {
        public List<UserMasterRes> lstUserList { get; set; }
    }
}