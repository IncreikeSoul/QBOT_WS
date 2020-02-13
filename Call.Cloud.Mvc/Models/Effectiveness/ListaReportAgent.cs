
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ListaReportAgent
    {
        public ReportsVm Filtro { get; set; }
        public IEnumerable<ReportsVm> Elementos { get; set; }

        public IEnumerable<SelectListItem> ListarBoss { get; set; }

        public ListaReportAgent(ReportsVm filtro, IEnumerable<ReportsVm> listaReport,IEnumerable<Agent> listaboss)
        {
            Filtro = filtro;
            Elementos = listaReport;
            ListarBoss = listaboss.GenerarLista(true);
        }
    }
}