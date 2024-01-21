using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class OpeningModel
    {
        public class OpeningModelReq : ErrorRes
        {
            public string dbAction { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public string active { get; set; }
            public string validDate { get; set; }
            public string resumeLink { get; set; }
            public string loginId { get; set; }
            public string authzList { get; set; }
        }

        public class OpeningModelRes
        {
            public string recordId { get; set; }
            public string mobile { get; set; }
            public string email { get; set; }
            public string title { get; set; }
            public string imgUrl { get; set; }
            public string companyName { get; set; }
            public string description { get; set; }
            public string createdBy { get; set; }
            public string createdOn { get; set; }
        }

        public class OpeningListRes : ErrorRes
        {
            public List<OpeningModelRes> lstOpenings { get; set; }

        }
    }
}