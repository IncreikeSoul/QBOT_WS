using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class Rule
    {
        public int PkRule { get; set; }
        public int PkSection { get; set; }
        public int PkSpeech { get; set; }
        public string SpeechName { get; set; }
        public string NameRule { get; set; }
        public decimal TimeRule { get; set; }
        public decimal wieght { get; set; }
        public string SeccionName { get; set; }
        public bool Status { get; set; }

        public List<WordRule> wordRule { get; set; }
        public int PkWordRule { get; set; }
        public string Word { get; set; }
        public int Sequence { get; set; }
        public decimal Weight { get; set; }
        public decimal TimeWord { get; set; }

    }
}
