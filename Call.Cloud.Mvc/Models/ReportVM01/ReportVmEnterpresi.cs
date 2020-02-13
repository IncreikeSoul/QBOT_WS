using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ReportVmEnterpresi
    {
        //primera grafica

        public string cantNocumpl { get; set; }
        public string cantCumpi { get; set; }

        public int PortnoCumpl { get; set; }
        public int portCumpli { get; set; }
        public string año { get; set; }
        public string Name_Enterprise { get; set; }
        public string pk_enter { get; set; }
        public string  pk_Enterprise04 { get; set; }
        //segunda grafica
        public string fecha { get; set; }
        public double PortnoCumpl1 { get; set; }
        public double PortCumpl1 { get; set; }
        public string cantNocumpl1 { get; set; }
        public string cantCumpi1 { get; set; }

        //tercera grafica
        public string cantNocumpl2 { get; set; }
        public string cantCumpi2 { get; set; }
        public decimal PortnoCumpl2 { get; set; }
        public decimal PortCumpl2 { get; set; }
        public string dias { get; set; }
        public string name_Enterprise1 { get; set; }
        public string name_enterprise2 { get; set; }

        //parametros de grafica 1
        public string añoPa { get; set; }
        public string  codigoEmpre { get; set; }
        public string codigoEmpre001 { get; set; }
        public string pk_enterprise11 { get; set; }

        //parametros de grafica 2
        public string añoPa1 { get; set; }

        public string codigoEmpre1 { get; set; }

        //parametros de grafica 3
        public string codigoEmpre2 { get; set; }
        public string ParaMes { get; set; }
        public string añoPa2 { get; set; }

        //parametros de grafica stack bar
        public string Enterpresi { get; set; }
    }
}