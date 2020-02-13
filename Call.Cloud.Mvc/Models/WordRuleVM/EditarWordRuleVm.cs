using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.WordRuleVM
{
    public class EditarWordRuleVm
    {
        public WordRule Item { get; set; }
        public IEnumerable<SelectListItem> Reglas { get; set; }
        public EditarWordRuleVm(WordRule item, IEnumerable<Rule> reglas)
        {
            Item = item;
            Reglas = reglas.GenerarLista();
        }
    }
}