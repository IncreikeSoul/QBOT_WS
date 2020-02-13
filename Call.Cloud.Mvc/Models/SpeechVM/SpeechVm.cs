using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.SpeechVM
{
    public class SpeechVm
    {
        public int PkSpeech { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PkSubOffice { get; set; }
        public string NameSubOffice { get; set; }


        public int PkRule { get; set; }
        public int PkCat { get; set; }
        public int PkSection { get; set; }
        
        public decimal TimeRule { get; set; }

        public string SeccionName { get; set; }
        public string CategoryName { get; set; }

    }
}