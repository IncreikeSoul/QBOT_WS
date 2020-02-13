using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Models.RuleVM
{
    public class EditarRuleVm
    {
        public Rule Item { get; set; }
        public IEnumerable<SelectListItem> Secciones { get; set; }
        public EditarRuleVm(Rule item, IEnumerable<Section> secciones)
        {
            Item = item;
            Secciones = secciones.GenerarLista();
        }
    }
}