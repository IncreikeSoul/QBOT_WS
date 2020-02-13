using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ReportVmAgent
    {

        //grafica de agent por año
        public string codigo { get; set; }
        public decimal  cantidad { get; set; }
        public int año { get; set; }
        public string nombreAgent { get; set; }
        public string nombre_agente { get; set; }
        public string  nameSection { get; set; }
      
        //grafica de agente por mes
        public string mes { get; set; }
        public int cantidad1 { get; set; }
        public string name_anget { get; set; }
        public string pk_agent01 { get; set; }

        //Grafica por dia 
        public int cantidad2 { get; set; }
        public string dias { get; set; }
        public string  name_agentt { get; set; }
        
        //grafica por llamada
        public string hora { get; set; }
        public int cantidad000 { get; set; }

        //parametros por año
        public string pk_supervisor { get; set; }
        public string añoParametro { get; set; }

        //parametros por mes

        public string  pk_agent { get; set; }
        public string Year_Parm { get; set; }

        //parametros por dia

        public string pk_Boss_param { get; set; }
        public string Month_param { get; set; }
        public string YearParam { get; set; }

        //parametro por llamada
        public string Para_pkagente { get; set; }
        public string para_fecha { get; set; }

        //Segmentado
        public decimal result01 { get; set; }
        public decimal result02 { get; set; }
        public decimal result03 { get; set; }
        public decimal result04 { get; set; }
        public string secction01 { get; set; }
        public string secction02 { get; set; }
        public string secction03 { get; set; }
        public string secction04 { get; set; }
    }
}