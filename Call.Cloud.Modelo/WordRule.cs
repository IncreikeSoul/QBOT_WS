using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class WordRule
    {
        public int PkWorldRule { get; set; }
        public int PkRule { get; set; }
        public string Word { get; set; }
        public int Sequence { get; set; }
        public decimal Weight { get; set; }
        public decimal TimeWord { get; set; }

        public List<Rule> reglas { get; set; }
        public string RuleName { get; set; }
        public string name {get; set; }

        public int fk_Section { get; set; }
        public int PkSpeech { get; set; }
        public string SpeechName { get; set; }
        public string SectionName { get; set; }
        public bool Status { get; set; }
        
    }
}
