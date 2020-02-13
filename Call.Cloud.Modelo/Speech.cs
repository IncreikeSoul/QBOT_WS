using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class Speech
    {
        //public int PkSpeech { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public int PK_Business { get; set; }
        //public string nameBusiness { get; set; }

        //public int PkSection { get; set; }
        //public string SectionName { get; set; }
        //public string SpeechName { get; set; }
        //public string descripcion { get; set; }
        //public decimal WeightSection { get; set; }
        //public decimal Wieght { get; set; }
        //public decimal weightWord { get; set; }
        //public int pkRule { get; set; }
        //public decimal TMO { get; set; }

        //public string SectionDetail { get; set; }
        //public List<Rule> Reglas { get; set; }
        //public List<Section> Secciones { get; set; }
        //public List<WordRule> WordRule { get; set; }
        //public string word { get; set; }
        //public bool Status { get; set; }
        public int PK_Speech { get; set; }
        public int PK_Enterprise { get; set; }
        public int PK_Office { get; set; }
        public int PK_SubOffice { get; set; }
        public int PK_Business { get; set; }
        public int Estado { get; set; }
        public string NameOffice { get; set; }
        public string NameSubOffice { get; set; }
        public string NameBusiness { get; set; }
        public string NameSpeech { get; set; }
        public object Description { get; set; }
        public string Tx_Estado { get; set; }
    }
}
