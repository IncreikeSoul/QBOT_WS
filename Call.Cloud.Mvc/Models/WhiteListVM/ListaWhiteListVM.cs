using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.WhiteListVM
{
    public class ListaWhiteListVM
    {
        public WhiteList Filtro { get; set; }
        public IEnumerable<WhiteList> Elementos { get; set; }
        public IEnumerable<SelectListItem> Pkenterprise { get; set; }
        public ListaWhiteListVM(WhiteList filtro, IEnumerable<WhiteList> listaWhite, IEnumerable<Enterprise> listaPKenterprise)
        {
            Filtro = filtro;
            Elementos = listaWhite;
            Pkenterprise = listaPKenterprise.GenerarLista(true);
        }
    }
}