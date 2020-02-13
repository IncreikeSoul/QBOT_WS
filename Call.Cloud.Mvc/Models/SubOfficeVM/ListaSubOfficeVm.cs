using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.SubOfficeVM
{
    public class ListaSubOfficeVm
    {
  
        public SubOffice Filtro { get; set; }
        public IEnumerable<SubOffice> Elementos { get; set; }
        public IEnumerable<SelectListItem> Offices { get; set; }

        public ListaSubOfficeVm(SubOffice filtro, IEnumerable<SubOffice> listaSubOffice, IEnumerable<Office> office)
        {
            Filtro = filtro;
            Elementos = listaSubOffice;
            Offices = office.GenerarLista(true);
        }

 
    }
}