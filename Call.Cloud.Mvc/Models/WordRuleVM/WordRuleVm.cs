using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.WordRuleVM
{
    public class WordRuleVm
    {
        public int PkWorldRule { get; set; }
        public int PkRule { get; set; }
        public string Word { get; set; }
        public int Sequence { get; set; }
        public decimal TimeWord { get; set; }
        public decimal Weight { get; set; }

        public string RuleName { get; set; }
    }
}