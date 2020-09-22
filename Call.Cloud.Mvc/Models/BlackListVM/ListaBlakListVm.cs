using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.BlackListVM
{
    public class ListaBlakListVm
    {
        public BlackList Filtro { get; set; }
        public IEnumerable<BlackList> Elementos { get; set; }
        public IEnumerable<SelectListItem> Pkenterprise { get; set; }
        public ListaBlakListVm(BlackList filtro, IEnumerable<BlackList> lista)
        {
            Filtro = filtro;
            Elementos = lista;
        }
    }
}