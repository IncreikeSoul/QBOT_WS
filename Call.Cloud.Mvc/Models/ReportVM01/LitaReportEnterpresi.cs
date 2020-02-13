using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.ReportVM01
{
    public class LitaReportEnterpresi
    {

        public ReportVmEnterpresi Filtro { get; set; }
        public IEnumerable<ReportVmEnterpresi> Elementos { get; set; }

        public IEnumerable<SelectListItem> listaEnterprise { get; set; }

        public LitaReportEnterpresi(ReportVmEnterpresi filtro, IEnumerable<ReportVmEnterpresi> listaReport, IEnumerable<Enterprise>ListarEnterprise )
        {
            Filtro = filtro;
            Elementos = listaReport;
            listaEnterprise = ListarEnterprise.GenerarLista(true);
        }

       
    }
}