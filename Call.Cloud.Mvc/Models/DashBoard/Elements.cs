using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.DashBoard
{
    public class Elements
    {
        public string PkAgent { get; set; }
        public string nameAgent { get; set; }
        public int result { get; set; }
        public string PkBusiness { get; set; }
        public string nameBusiness { get; set; }
        public string inicio { get; set; }
        public string fin { get; set; }
        public int QuantityCall { get; set; }
        public string nameBoss { get; set; }
        public int QuantityAgent { get; set; }
    }
}