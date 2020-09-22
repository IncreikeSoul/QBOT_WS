using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class WordRule_Details
    {
        public int pkWordRule_Detail { get; set; }
        public int PK_audio { get; set; }
        public int PK_WordRule { get; set; }
        public int PK_Rule { get; set; }
        public string word { get; set; }
        public decimal weight { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Section> secciones { get; set; }
        public List<Rule> reglas { get; set; }
        public List<WordRule> diccionario { get; set; }
    }
}
