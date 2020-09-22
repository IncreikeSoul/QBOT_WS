using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class Evaluacion
    {
        public int PK_Audio { get; set; }
        public int PK_Section { get; set; }
        public int PK_Rule { get; set; }
        public int PK_WordRule { get; set; }
        public string nom_section { get; set; }
        public string nom_rules { get; set; }
        public string descripcion { get; set; }
        public string weight { get; set; }
        public string porcentaje { get; set; }
        public string word { get; set; }
    }
}
