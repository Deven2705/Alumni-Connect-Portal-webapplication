using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniConnect.Model
{
    public class ErrorRes
    {
        public string recordId { get; set; }
        public string errorMsg { get; set; }
        public string errorFlag { get; set; }
        public string errorCode { get; set; }
    }
}