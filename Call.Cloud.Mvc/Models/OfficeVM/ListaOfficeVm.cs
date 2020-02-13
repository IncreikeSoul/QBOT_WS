using System;
using Call.Cloud.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.OfficeVM
{
    public class ListaOfficeVm
    {


        public Office Filtro { get; set; }
        public IEnumerable<Office> Elementos { get; set; }
        public IEnumerable<SelectListItem> Enterprise { get; set; }

        public ListaOfficeVm(Office filtro, IEnumerable<Office> listaOffice, IEnumerable<Enterprise> enterprise)
        {
            Filtro = filtro;
            Elementos = listaOffice;
            Enterprise = enterprise.GenerarLista(true);
        }




    }
}