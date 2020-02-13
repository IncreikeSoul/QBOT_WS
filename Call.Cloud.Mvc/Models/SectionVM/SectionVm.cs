using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.SectionVM
{
    public class SectionVm
    {
        public int PkSection { get; set; }
        public string Name { get; set; }
        public int PkSpeech { get; set; }
        public decimal Weight { get; set; }
        public decimal TMO { get; set; }

        public string SectionName { get; set; }
        public string SpeechName { get; set; }

        //wordrule
        public int PkWorldRule { get; set; }
        public int PkRule { get; set; }
        public string Word { get; set; }
        public int Sequence { get; set; }
        public decimal TimeWord { get; set; }
        

        public string RuleName { get; set; }



    }
}