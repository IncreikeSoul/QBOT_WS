using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ListaReportBoss
    {
        public ReportsVm Filtro { get; set; }
        public IEnumerable<ReportsVm> Elementos { get; set; }

        public IEnumerable<SelectListItem> ListarBusiness { get; set; }

        public ListaReportBoss(ReportsVm filtro, IEnumerable<ReportsVm> listaReport, IEnumerable<Business> listabusiness)
        {
            Filtro = filtro;
            Elementos = listaReport;
            ListarBusiness = listabusiness.GenerarLista(true);
        }
    }
}