using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Models.ReportsVM
{
    public class ListaReportSubOffice
    {
        public ReportVmSubOffice Filtro { get; set; }
        public IEnumerable<ReportVmSubOffice> Elementos { get; set; }

        public IEnumerable<SelectListItem> listaOffice { get; set; }

        public ListaReportSubOffice(ReportVmSubOffice filtro, IEnumerable<ReportVmSubOffice> listaReport , IEnumerable<Office>listaroffice)
        {
            Filtro = filtro;
            Elementos = listaReport;
            listaOffice = listaroffice.GenerarLista(true);

        }

    }
}