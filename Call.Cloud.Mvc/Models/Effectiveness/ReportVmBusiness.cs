using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ReportVmBusiness
    {
        //Grafica por año
        public int cantidad { get; set; }
        public string año { get; set; }
        public string pk_Business{ get; set; }
        public string name_business { get; set; }


        //Grafica  por mes 
        public int cantidad1 { get; set; }
        public string mes { get; set; }
        public string name_Bunisess01 { get; set; }
        public string pk_business01 { get; set; }

        //Grafica por dias
        public string dias { get; set; }
        public int cantidad3 { get; set; }


        //parametros de la grafica por año
        public string pk_Business_Parm { get; set; }
        public string añoParametro { get; set; }


        //parametros de la grafica por mes 
        public string pk_Business_Par_month { get; set; }
        public string añoMonth { get; set; }

        //parametros de las grafica por dias 
        public string pk_Business_Day_parm { get; set; }
        public string Year_Param { get; set; }
        public string Month_para { get; set; }

    }
}