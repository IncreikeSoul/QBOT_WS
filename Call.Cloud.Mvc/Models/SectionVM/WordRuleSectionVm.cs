using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Call.Cloud.Mvc.Models.SectionVM
{
    public class WordRuleSectionVm
    {
        public int PkSection { get; set; }
        public int PkRule { get; set; }
        public int PkWordRule { get; set; }
        public int Sequence { get; set; }
        public string Word { get; set; }        
        public string Weight { get; set; }
        public string wieght { get; set; }
        public IEnumerable<Rule> Reglas { get; set; }
        public string Name { get; set; }
    }
}