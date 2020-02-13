using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class Section
    {
        //public int PkSection { get; set; }
        //public int PkSpeech { get; set; }
        //public string description { get; set; }
        //public decimal Weight { get; set; }
        //public decimal TMO { get; set; }
        //public string SectionName { get; set; }
        //public string SpeechName { get; set; }

        //public List<Rule> Reglas { get; set; }
        //public int PkRule { get; set; }
        //public string NameRule { get; set; }
        //public decimal wieght { get; set; }
        //public int PkWordRule { get; set; }

        //public List<WordRule> WordRule { get; set; }
        //public int Sequence { get; set; }
        //public string Word { get; set; }
        //public bool Status { get; set; }
        public int PK_Section { get; set; }
        public int PK_Enterprise { get; set; }
        public int PK_Office { get; set; }
        public int PK_SubOffice { get; set; }
        public int PK_Business { get; set; }
        public int PK_Speech { get; set; }
        public string NameSection { get; set; }
        public string NameSpeech { get; set; }
        public string Description { get; set; }
        public int Estado { get; set; }
        public string Tx_Estado { get; set; }
        public decimal Weight { get; set; }
        public decimal TMO { get; set; }
    }
}
