using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ReportVmBoss
    {

        //Grafica por año
        public string cantNocumpl { get; set; }
        public string cantCumpi { get; set; }
        public string name_boss { get; set; }
        public decimal PortnoCumpl { get; set; }
        public decimal portCumpli { get; set; }
        public int año { get; set; }
        public string pk_Boss { get; set; }
        public string name_boss_year { get; set; }
        //grafica por mes
        public string mes { get; set; }
        public string cantNocumpl1 { get; set; }
        public string cantCumpi1 { get; set; }
        public string name { get; set; }
        public decimal PortnoCumpl1 { get; set; }
        public decimal portCumpli1 { get; set; }

        //grafica por dia 

        public string cantNocumpl2 { get; set; }
        public string cantCumpi2 { get; set; }
        public string name_boss_day { get; set; }
        public decimal PortnoCumpl2 { get; set; }
        public decimal portCumpli2 { get; set; }
        public string dia { get; set; }

        //parametros de la grafica por año
        public string pk_business { get; set; }
        public string añoParametro { get; set; }
        //parametros por mes
        public string pk_Boss_Parm { get; set; }
        public string Year_Parm { get; set; }

        //parametros por dia
        public string pk_Boss_Parm1 { get; set; }
        public string month_Pam { get; set; }
        public string Year_Parm1 { get; set; }
    }
}