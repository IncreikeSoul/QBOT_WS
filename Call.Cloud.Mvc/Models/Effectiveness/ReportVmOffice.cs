using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ReportVmOffice
    {

        // GRAFICAS POR OFICINA
        //primera grafica
        public string añoofi { get; set; }
        public int cantidadoffice { get; set; }
        public int  pk_off1 { get; set; }
        public string pk_off { get; set; }
        public string name_office { get; set; }

        //segunda grafica por oficina

        public int cantidadOfic { get; set; }
        public string mesof { get; set; }
        public string name { get; set; }
        public string pk_office11 { get; set; }


        // tercer grafico 
        public int cantidadDay { get; set; }
        public string MountDay { get; set; }
        //parametros DAY
        public string pk_office { get; set; }
        public string YearPa { get; set; }
        public string MonthPa { get; set; }

        //parametros de Year por oficina
        public string codigoEmpresa { get; set; }
        public string añoParametro { get; set; }

        // parametros office month
        public string codigoOff { get; set; }
        public string añooff { get; set; }
     
    }
}