using System.Collections.Generic;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ReportsVm
    {
      //primera grafica
        public int cantidad { get; set; }
        public string año { get; set; }
        public string name_enterprise { get; set; }
        public string id_enterprise { get; set; }

        //Reporte eficacia Empresa
        public decimal result { get; set; }
        public int quantityOffice { get; set; }
        public int quantityCall { get; set; }
        public string dateCreate { get; set; }

        //Reporte eficacia Office
        public string pk_office { get; set; }
        public string name_office { get; set; }
        public int quantitySubOffice { get; set; }
        public string PkReport { get; set; }
        public decimal criterio { get; set; }

        //Reporte eficacia SubOffice
        public string nameSubOffice { get; set; }
        public int quantityBusiness { get; set; }
        public string pkSubOffice { get; set; }

        //Reporte eficacia Business
        public string nameBusiness { get; set; }
        public string pkBusiness { get; set; }
        public string pkSpeech { get; set; }
        public string pkSection { get; set; }
        public string nameSection { get; set; }
        public int quantityBoss { get; set; }

        //Reporte  eficacia Boss
        public string pkBoss { get; set; }
        public string nameBoss { get; set; }

        //Reporte eficacia Agente
        public string pkAgent { get; set; }
        public string nameAgent { get; set; }
        public string hora { get; set; }
        public int quantityAgent { get; set; }
        public int quantity { get; set; }
        public string pkAudio { get; set; }

        //Reporte eficacia por mes
        public string month { get; set; }

        //segunda grafica
        public string fecha { get; set; }
        public int cantidad1 { get; set; }
        public string name { get; set; }
        public string pk_enterprise { get; set; }

        //tercera grafica
        public int cantidad2 { get; set; }
        public string dias { get; set; }

        //parametros de grafica 1
        public string añoPa { get; set; }

        public string codigoEmpre { get; set; }

        //parametros de grafica 2
        public string añoPa1 { get; set; }

        public string codigoEmpre1 { get; set; }

        //parametros de grafica 3
        public string  codigoEmpre2 { get; set; }
        public string ParaMes { get; set; }
        public string añoPa2 { get; set; }

        //parametros de grafica stack bar
        public string Enterpresi { get; set; }


        //Segmentado
        public decimal result1 { get; set; }
        public decimal result2 { get; set; }
        public decimal result3 { get; set; }
        public decimal result4 { get; set; }
        public decimal result5 { get; set; }
        public string name_secction1 { get; set; }
        public string name_secction2 { get; set; }
        public string name_secction3 { get; set; }
        public string name_secction4 { get; set; }
        public string name_secction5 { get; set; }
        public string pkSection01 { get; set; }
        public string pkSection02 { get; set; }
        public string pkSection03 { get; set; }
        public string pkSection04 { get; set; }
        public string pkSection05 { get; set; }
        
        public string name_rule { get; set; }

        public List<AudioVM.AudioVm> AudioRule { get; set; }
        //detalle audio
        public int QuantityRepeatedRule { get; set; }
        public string fileName { get; set; }
        public string direccionAudio { get; set; }
        public float starSecond { get; set; }
        public float endSecond { get; set; }
        public string pk_Rule { get; set; }
        public int state { get; set; }

        /*Adicionales */
        public double PesoSeccion { get; set; }
        public double PesoRegla { get; set; }
        public double Cumplimiento { get; set; }
        public double Total { get; set; }

    }
}

