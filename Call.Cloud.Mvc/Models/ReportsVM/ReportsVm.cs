using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.ReportsVM
{
    public class ReportsVm
    {
      //primera grafica

        public int cantidad { get; set; }
        public string año { get; set; }
        public string name_enterprise { get; set; }
        public string id_enterprise { get; set; }
        //segunda grafica
        public string fecha { get; set; }
        public int cantidad1 { get; set; }
        public string name { get; set; }
        public string pk_enterprise { get; set; }

        //tercera grafica
        public int cantidad2 { get; set; }
        public string dias { get; set; }

        //parametros de grafica 1
        public string añoPa { get; set; }

        public string codigoEmpre { get; set; }

        //parametros de grafica 2
        public string añoPa1 { get; set; }

        public string codigoEmpre1 { get; set; }

        //parametros de grafica 3
        public string  codigoEmpre2 { get; set; }
        public string ParaMes { get; set; }
        public string añoPa2 { get; set; }

        //parametros de grafica stack bar
        public string Enterpresi { get; set; }



    }
}