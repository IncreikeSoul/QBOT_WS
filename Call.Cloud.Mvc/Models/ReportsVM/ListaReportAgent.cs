using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Models.ReportsVM
{
    public class ListaReportAgent
    {
        public ReportVmAgent Filtro { get; set; }
        public IEnumerable<ReportVmAgent> Elementos { get; set; }



        public IEnumerable<SelectListItem> listarAgente { get; set; }


        public ListaReportAgent(ReportVmAgent filtro, IEnumerable<ReportVmAgent> listaReport, IEnumerable<Agent> listAgent)
        {
            Filtro = filtro;
            Elementos = listaReport;
            listarAgente = listAgent.GenerarLista(true);

        }
        public string Notifiaciones { get; set;}

    }
}