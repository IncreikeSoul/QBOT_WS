using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;


namespace Call.Cloud.Mvc.Models.SpeechVM 
{
    public class EditarSpeechVm
    {
        public Speech Item { get; set; }
        public IEnumerable<SelectListItem> Business { get; set; }
        public EditarSpeechVm(Speech item, IEnumerable<Business> listaBusiness)
        {
            Item = item;
            Business = listaBusiness.GenerarLista();
        }
    }
}