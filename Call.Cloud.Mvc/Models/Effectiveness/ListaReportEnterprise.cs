using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ListaReportEnterprise
    {
        public ReportsVm Filtro { get; set; }
        public IEnumerable<ReportsVm> Elementos { get; set; }

        public IEnumerable<SelectListItem> ListaEnterprise { get; set; }

        public ListaReportEnterprise(ReportsVm filtro, IEnumerable<ReportsVm> listaReport, IEnumerable<Enterprise> listaempresa)
        {
            Filtro = filtro;
            Elementos = listaReport;
            ListaEnterprise = listaempresa.GenerarLista(true);
        }

    }
}