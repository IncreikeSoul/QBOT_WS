using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Modelo;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ListaReportOffice
    {

        public ReportsVm Filtro { get; set; }
        public IEnumerable<ReportsVm> Elementos { get; set; }

        public IEnumerable<SelectListItem> ListaEnterprise { get; set; }

        public ListaReportOffice(ReportsVm filtro, IEnumerable<ReportsVm> listaReport, IEnumerable<Enterprise> listaempresa)
        {
            Filtro = filtro;
            Elementos = listaReport;
            ListaEnterprise = listaempresa.GenerarLista(true);
        }
    }
}