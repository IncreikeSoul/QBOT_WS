using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ReportVmBoss
    {
        //Grafica por año
        public int cantidad { get; set; }
        public int año { get; set; }
        public string año1 { get; set; }
        public string pk_Boss { get; set; }
        public string name_Boss { get; set; }

        //grafica por mes
        public string mes { get; set; }
        public int cantidad1 { get; set; }
        public string  pk_Boss01 { get; set; }
        public string name_Boss001 { get; set; }
        public string name_Boss01 { get; set; }

        //grafica por dia 

        public int cantidad2 { get; set; }
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

        //Segmentado
        public decimal result1 { get; set; }
        public decimal result2 { get; set; }
        public decimal result3 { get; set; }
        public decimal result4 { get; set; }
        public string name_secction1 { get; set; }
        public string name_secction2 { get; set; }
        public string name_secction3 { get; set; }
        public string name_secction4 { get; set; }
        public string pkBusiness { get; set; }
    }
}