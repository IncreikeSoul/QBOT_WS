using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class AudioEva
    {
        public int PK_audio { get; set; }
        public string duracion { get; set; }
        public string dateCreated { get; set; }
        public string filesize { get; set; }
        public string transcription { get; set; }
        public string fileName { get; set; }
        public string porcentaje { get; set; }
        public int FK_Agent { get; set; }
        public int FK_Speech { get; set; }
        public int FK_Business { get; set; }
        public int PK_SubOffice { get; set; }
        public int PK_Office { get; set; }
        public int PK_Enterprise { get; set; }
    }
}
