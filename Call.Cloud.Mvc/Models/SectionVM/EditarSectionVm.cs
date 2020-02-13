using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;
namespace Call.Cloud.Mvc.Models.SectionVM
{
    public class EditarSectionVm
    {
        public Section Item { get; set; }
        public IEnumerable<SelectListItem> Speechs { get; set; }
        public EditarSectionVm(Section item, IEnumerable<Speech> listaSpeech)
        {
            Item = item;
            Speechs = listaSpeech.GenerarLista();
        }
    }
}