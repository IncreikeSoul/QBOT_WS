using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class SubOffice
    {
        public int Pk_SubOffice { get; set; }
        public int Pk_Office { get; set; }
        public int Pk_Enterprise { get; set; }
        public string nameSubOffice { get; set; }
        public string nameOffice { get; set; }
        public int Estado { get; set; }
        public string Tx_Estado { get; set; }
    }
}
