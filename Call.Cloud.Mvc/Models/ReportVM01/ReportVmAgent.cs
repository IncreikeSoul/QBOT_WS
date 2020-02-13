using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ReportVmAgent
    {

        //grafica de agent por año
        public string codigo { get; set; }
        public string cantNocumpl { get; set; }
        public string cantCumpi { get; set; }
        public string name_agent { get; set; }
        public decimal PortnoCumpl { get; set; }
        public decimal portCumpli { get; set; }
        public int año { get; set; }
        public string nombreAgent { get; set; }


        //grafica de agente por mes
        public string mes { get; set; }
        public string cantNocumpl1 { get; set; }
        public string cantCumpi1 { get; set; }
        public string name { get; set; }
        public decimal PortnoCumpl1 { get; set; }
        public decimal portCumpli1 { get; set; }

        //Grafica por dia 

        public string cantNocumpl2 { get; set; }
        public string cantCumpi2 { get; set; }
        public string name_agent_day { get; set; }
        //Grafica por llamada
        public string hora { get; set; }
        public int CantCumpl0001 { get; set; }
        public int cantNoCumpl0001 { get; set; }
        public string name_agent_call { get; set; }
        public decimal PortnoCumpl2 { get; set; }
        public decimal portCumpli2 { get; set; }
        public string dias { get; set; }

        //parametros por año
        public string pk_supervisor { get; set; }
        public string añoParametros { get; set; }

        //parametros por mes

        public string pk_agent { get; set; }
        public string Year_Parm { get; set; }

        //parametros por dia

        public string pk_Boss_param { get; set; }
        public string Month_param { get; set; }
        public string YearParam { get; set; }

        //paramatros por llamadas
        public string Param_pk_Agente { get; set; }
        public string Param_Date { get; set; }
    }
}