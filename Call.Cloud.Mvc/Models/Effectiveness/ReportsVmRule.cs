using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ReportsVmRule
    {
        public string pkAudio { get; set; }
        public string pkSection { get; set; }
        public string nameSection { get; set; }
        public string pkAgent { get; set; }
        public string nameAgent { get; set; }
        public string hora { get; set; }                 
        public string dias { get; set; }
        public string pkRule { get; set; }
        public string nameRule { get; set; }
        public double start { get; set; }
        public double end { get; set; }
        public string direccion { get; set; }
        public string nameaudio { get; set; }

        //public List<ReportsVm> ReportsVm { get; set; }
    }
}

