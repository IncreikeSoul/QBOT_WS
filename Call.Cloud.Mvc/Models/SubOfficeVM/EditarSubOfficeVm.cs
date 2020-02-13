using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.SubOfficeVM
{
    public class EditarSubOfficeVm
    {

        public SubOffice Item { get; set; }
        public IEnumerable<SelectListItem> Office { get; set; }

        public EditarSubOfficeVm(SubOffice item, IEnumerable<Office> office)
        {
            Item = item;
            Office = office.GenerarLista();
        }
    }
}