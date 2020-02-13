using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.Effectiveness
{
    public class ListarReports
    {

        public ReportsVm Filtro { get; set; }
        public IEnumerable<ReportsVm> Elementos { get; set; }

        public IEnumerable<SelectListItem> listaraño { get; set; }
        
        public ListarReports(ReportsVm filtro, IEnumerable<ReportsVm> listaReport )
        {
            Filtro = filtro;
            Elementos = listaReport;
          
        }
    }
}