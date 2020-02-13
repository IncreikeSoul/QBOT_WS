using Call.Cloud.Modelo;
using System.Collections.Generic;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Models.SpeechVM
{
    public class ListaSpeechVm
    {
        public Speech Filtro { get; set; }
        public IEnumerable<Speech> Elementos { get; set; }
        public IEnumerable<SelectListItem> Business { get; set; }
        public IEnumerable<Section> Secciones { get; set; }
        
        public ListaSpeechVm(Speech filtro, IEnumerable<Speech> listaSpeech, IEnumerable<Business> listaBusiness, IEnumerable<Section> listasecciones)
        {
            Filtro = filtro;
            Elementos = listaSpeech;
            Business =listaBusiness.GenerarLista(true);
            Secciones = listasecciones;
        }

    }
}