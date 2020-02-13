using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Modelo;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ListaReportSubOffice
    {
        public ReportsVm Filtro { get; set; }
        public IEnumerable<ReportsVm> Elementos { get; set; }

        public IEnumerable<SelectListItem> ListaOffice { get; set; }

        public ListaReportSubOffice(ReportsVm filtro, IEnumerable<ReportsVm> listaReport, IEnumerable<Office> listaoffice)
        {
            Filtro = filtro;
            Elementos = listaReport;
            ListaOffice = listaoffice.GenerarLista(true);
        }
    }
}