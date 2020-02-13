using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Call.Cloud.Mvc.Models.LoginVm
{
    public class ListarLoginVm
    {
        public Login_User Filtro { get; set; }
        public IEnumerable<Login_User> Elementos { get; set; }
        public IEnumerable<string> ListarAlertas { get; set; }

        public ListarLoginVm(Login_User filtro, IEnumerable<Login_User> listaLogin_User, IEnumerable<string> listaAlertas)
        {
            Filtro = filtro;
            Elementos = listaLogin_User;
            ListarAlertas = listaAlertas;
        }
    }
}