using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class ListaReportBoss
    {

        public ReportVmBoss Filtro { get; set; }
        public IEnumerable<ReportVmBoss> Elementos { get; set; }

        public IEnumerable<SelectListItem> listaBusiness { get; set; }

        public ListaReportBoss(ReportVmBoss filtro, IEnumerable<ReportVmBoss> listaReport, IEnumerable<Business> ListarBusiness)
        {
            Filtro = filtro;
            Elementos = listaReport;
            listaBusiness = ListarBusiness.GenerarLista(true);
        }

    }
}