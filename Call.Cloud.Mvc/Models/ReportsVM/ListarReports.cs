using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Call.Cloud.Mvc.Models.ReportsVM
{
    public class ListarReports
    {

        public ReportsVm Filtro { get; set; }
        public IEnumerable<ReportsVm> Elementos { get; set; }

        public IEnumerable<SelectListItem> listaempresa { get; set; }

        public ListarReports(ReportsVm filtro, IEnumerable<ReportsVm> listaReport, IEnumerable<Enterprise> listaEnterprise)
        {
            Filtro = filtro;
            Elementos = listaReport;
            listaempresa = listaEnterprise.GenerarLista(true);
          
        }
    }
}