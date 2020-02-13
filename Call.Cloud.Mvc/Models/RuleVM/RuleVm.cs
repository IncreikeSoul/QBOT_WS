using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.RuleVM
{
    public class RuleVm
    {
        public int PkRule { get; set; }
        public int PkCat { get; set; }
        public int PkSection { get; set; }
        public string Name { get; set; }
        public decimal TimeRule { get; set; }
        public decimal wieght { get; set; }

        public string SeccionName { get; set; }
        public string CategoryName { get; set; }
    }
}