using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class FilterModel
    {
    }

    public class FilterReq : ErrorRes
    {
        public string dbAction { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string batch { get; set; }
        public string country { get; set; }
        public string bloodGroup { get; set; }
        public string profession { get; set; }
        public string branch { get; set; }
        public string role { get; set; }
    }
}