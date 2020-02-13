using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.Models.ReportVM01;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ListaReportOffice
    {
        public ReporVmOffice  Filtro { get; set; }
        public IEnumerable<ReporVmOffice> Elementos { get; set; }

        public IEnumerable<SelectListItem> listEmpresa { get; set; }

        public ListaReportOffice(ReporVmOffice filtro, IEnumerable<ReporVmOffice> listaReport, IEnumerable<Enterprise> listEnterprise)
        {
            Filtro = filtro;
            Elementos = listaReport;
            listEmpresa = listEnterprise.GenerarLista(true);
        }
    }
}