using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Mvc.Models.ReportsVM;
using System.Web.Mvc;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ListaReportBusiness
    {
        public ReportsVm Filtro { get; set; }
        public IEnumerable<ReportsVm> Elementos { get; set; }
        public IEnumerable<SelectListItem> ListaSubOffice { get; set; }

        public ListaReportBusiness(ReportsVm filtro, IEnumerable<ReportsVm> listaReport, IEnumerable<SubOffice> listasuboffice)
        {
            Filtro = filtro;
            Elementos = listaReport;
            ListaSubOffice = listasuboffice.GenerarLista(true);
        }

    }
}