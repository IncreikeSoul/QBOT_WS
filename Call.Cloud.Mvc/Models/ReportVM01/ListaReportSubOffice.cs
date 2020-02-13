using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ListaReportSubOffice
    {

        public ReportVmSubOffice Filtro { get; set; }
        public IEnumerable<ReportVmSubOffice> Elementos { get; set; }

        public IEnumerable<SelectListItem> listaOffice { get; set; }

        public ListaReportSubOffice(ReportVmSubOffice filtro, IEnumerable<ReportVmSubOffice> listaReport, IEnumerable<Office> listaroffice)
        {
            Filtro = filtro;
            Elementos = listaReport;
            listaOffice = listaroffice.GenerarLista(true);
        }

    }
}