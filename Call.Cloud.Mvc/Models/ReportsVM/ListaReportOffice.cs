using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.ReportsVM
{
    public class ListaReportOffice
    {

        public ReportVmOffice Filtro { get; set; }
        public IEnumerable<ReportVmOffice> Elementos { get; set; }

        public IEnumerable<SelectListItem> listEmpresa { get; set; }

        public ListaReportOffice(ReportVmOffice filtro, IEnumerable<ReportVmOffice> listaReport, IEnumerable<Enterprise>listEnterprise)
        {
            Filtro = filtro;
            Elementos = listaReport;
            listEmpresa = listEnterprise.GenerarLista(true);

        }
    }
}