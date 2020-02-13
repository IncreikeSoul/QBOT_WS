using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ReportVmBusiness
    {
        //Grafica por año
        public string cantNocumpl { get; set; }
        public string cantCumpi { get; set; }
        public string name_Business { get; set; }
        public decimal PortnoCumpl { get; set; }
        public decimal portCumpli { get; set; }
        public string año { get; set; }
        public string pk_Business { get; set; }
        public string name_Business_year { get; set; }

        //Grafica  por mes 
        public string cantNocumpl1 { get; set; }
        public string cantCumpi1 { get; set; }
        public string name { get; set; }
        public decimal PortnoCumpl1 { get; set; }
        public decimal portCumpli1 { get; set; }

        public string mes { get; set; }

        //Grafica por dias
        public string dias { get; set; }
        public string cantNocumpl2 { get; set; }
        public string cantCumpi2 { get; set; }
        public string name_Business_Day { get; set; }
        public decimal PortnoCumpl2 { get; set; }
        public decimal portCumpli2 { get; set; }


        //parametros de la grafica por año
        public string pk_Business_Parm { get; set; }
        public string añoPamaretro { get; set; }


        //parametros de la grafica por mes 
        public string pk_Business_Par_month { get; set; }
        public string añoMonth { get; set; }

        //parametros de las grafica por dias 
        public string pk_Business_Day_parm { get; set; }
        public string Year_Param { get; set; }
        public string Month_para { get; set; }
    }
}