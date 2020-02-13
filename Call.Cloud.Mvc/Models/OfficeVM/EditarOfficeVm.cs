using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.OfficeVM
{
    public class EditarOfficeVm
    {

        public Office Item { get; set; }
        public IEnumerable<SelectListItem> Enterprise { get; set; }
        public EditarOfficeVm(Office item, IEnumerable<Enterprise> enterprise)
        {
            Item = item;
            Enterprise = enterprise.GenerarLista();
        }
    }
}