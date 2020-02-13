using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call.Cloud.Modelo
{
    public class Office
    {
        public int Pk_Office { get; set; }
        public int Pk_Enterprise { get; set; }
        public string Name { get; set; }
        public int Estado { get; set; }
        public string Tx_Estado { get; set; }
    }
}
