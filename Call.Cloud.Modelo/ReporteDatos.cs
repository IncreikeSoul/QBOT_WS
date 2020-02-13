using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class ReporteDatos
    {
        public int PK_Speech { get; set; }
        public int PK_audio { get; set; }
        public string TX_Business { get; set; }
        public string TX_Speech { get; set; }
        public string TX_Transcripcion { get; set; }
        public decimal NU_WordWeight { get; set; }
        public string TX_Section { get; set; }
        public decimal NU_SectionWeight { get; set; }
        public string TX_Rule { get; set; }
        public decimal NU_RuleWeight { get; set; }
        public string TX_Word { get; set; }
        public string TX_WordAudio { get; set; }
    }
}
