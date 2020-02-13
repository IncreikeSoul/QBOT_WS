using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Call.Cloud.Mvc.Models.LoginVm
{
    public class ListaLogin
    {
         public Login_User Filtro { get; set; }
        public IEnumerable<Login_User> Elementos { get; set; }
        public IEnumerable<SelectListItem> SubOffice { get; set; }
        public ListaLogin(Login_User filtro, IEnumerable<Login_User> listaAgent)
        {
            Filtro = filtro;
            Elementos = listaAgent;
            //SubOffice = subOffice.GenerarLista(true);
        }
    }
}