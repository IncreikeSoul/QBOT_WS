using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ListaReportBusiness
    {

        public ReportVmBusiness Filtro { get; set; }
        public IEnumerable<ReportVmBusiness> Elementos { get; set; }

        public IEnumerable<SelectListItem> listarSubOffices { get; set; }

        public ListaReportBusiness(ReportVmBusiness filtro, IEnumerable<ReportVmBusiness> listaReport, IEnumerable<SubOffice> listaSubOffice)
        {
            Filtro = filtro;
            Elementos = listaReport;
            listarSubOffices = listaSubOffice.GenerarLista(true);

        }
    }
}