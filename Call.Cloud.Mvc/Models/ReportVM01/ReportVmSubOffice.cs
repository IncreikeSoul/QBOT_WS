using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ReportVmSubOffice
    {
        public string cantNocumpl { get; set; }
        public string cantCumpi { get; set; }
        public string name_subOffice_Year { get; set; }
        public decimal PortnoCumpl { get; set; }
        public decimal portCumpli { get; set; }
        public string año { get; set; }
        public string pk_subOffice { get; set; }
        public string name_subOffice { get; set; }

        //Grafica por month
        public string cantNocumpl1 { get; set; }
        public string cantCumpi1 { get; set; }
        public string name { get; set; }
        public decimal PortnoCumpl1 { get; set; }
        public decimal portCumpli1 { get; set; }
        public string mesSubOff { get; set; }

        //Grafica por dia
        public string cantNocumpl2 { get; set; }
        public string cantCumpi2 { get; set; }
        public string name_suboffice_day { get; set; }
        public decimal PortnoCumpl2 { get; set; }
        public decimal portCumpli2 { get; set; }
        public string dias { get; set; }

        //parametros de la grafica por año

        public string parm_Pk_office { get; set; }
        public string añoParametro { get; set; }

        //parametros de la grafica por mes
        public string YearPa { get; set; }
        public string pk_subOffice_Parm { get; set; }

        //parametros de la grafica por dia 
        public string pk_subOfficeDay { get; set; }
        public string añoDay { get; set; }
        public string mesDay { get; set; }

    }
}