using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Mvc.Models.ReportsVM;
using System.Web.Mvc;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
namespace Call.Cloud.Mvc.Models.ReportsVM
{
    public class ListaReportBusiness
    {
        public ReportVmBusiness Filtro { get; set; }
        public IEnumerable<ReportVmBusiness> Elementos { get; set; }

        public IEnumerable<SelectListItem> listarSubOffices { get; set; }

        public ListaReportBusiness(ReportVmBusiness filtro, IEnumerable<ReportVmBusiness> listaReport, IEnumerable<SubOffice>listaSubOffice)
        {
            Filtro = filtro;
            Elementos = listaReport;
            listarSubOffices = listaSubOffice.GenerarLista(true);

        }

    }
}