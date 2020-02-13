using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.ReportsVM
{
    public class ReportVmSubOffice
    {
        //Grafica por año
        public int cantidad { get; set; }
        public string año { get; set; }
        public string pk_subOffice { get; set; }
        public string name_suboffice { get; set; }

        //Grafica por month
        public int cantidadsuboff { get; set; }
        public string mesSubOff { get; set; }
        public string name { get; set; }
        public string pk_suboffice11 { get; set; }

        //Grafica por dia
        public int cantidadDay { get; set; }
        public string dias  { get; set; }

        //parametros de la grafica por año

        public string parm_Pk_office { get; set; }
        public string añoParametros { get; set; }

        //parametros de la grafica por mes
        public string YearPa { get; set; }
        public string pk_subOffice_Parm { get; set; }

        //parametros de la grafica por dia 
        public string pk_subOfficeDay { get; set; }
        public string añoDay { get; set; }
        public string  mesDay { get; set; }
    }
}