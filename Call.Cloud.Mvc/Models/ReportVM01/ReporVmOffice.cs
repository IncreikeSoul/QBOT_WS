using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ReporVmOffice
    {
        // GRAFICAS POR OFICINA
        //primera grafica
        public string cantNocumpl { get; set; }
        public string cantCumpi { get; set; }
        public string name_office_month { get; set; }
        public decimal PortnoCumpl { get; set; }
        public decimal portCumpli { get; set; }
        public string añoofi { get; set; }
        public string name_office_year { get; set; }

        public string pk_off { get; set; }
        public string name_office { get; set; }

        //segunda grafica por oficina

        public string cantNocumpl1 { get; set; }
        public string cantCumpi1 { get; set; }

        public decimal PortnoCumpl1 { get; set; }
        public decimal portCumpli1 { get; set; }
        public string mesof { get; set; }


        // tercer grafico 
        public string cantNocumpl2 { get; set; }
        public string cantCumpi2 { get; set; }
        public string name { get; set; }
        public decimal PortnoCumpl2 { get; set; }
        public decimal portCumpli2 { get; set; }

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