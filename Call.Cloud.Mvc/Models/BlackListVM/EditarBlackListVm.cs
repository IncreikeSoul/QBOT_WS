using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Modelo;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Models.BlackListVM
{
    public class EditarBlackListVm
    {
        public BlackList Item { get; set; }
        public IEnumerable<SelectListItem> PKEnterprise { get; set; }
        public EditarBlackListVm(BlackList item, IEnumerable<Enterprise> listapk)
        {
            Item = item;
            PKEnterprise = listapk.GenerarLista();
        }
    }
}