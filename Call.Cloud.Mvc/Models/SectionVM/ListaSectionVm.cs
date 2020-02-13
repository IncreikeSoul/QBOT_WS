using AutoMapper;
using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;  
namespace Call.Cloud.Mvc.Models.SectionVM
{
    public class ListaSectionVm
    {
        public Section Filtro { get; set; }
        public IEnumerable<Section> Elementos { get; set; }
        public IEnumerable<SelectListItem> Speechs { get; set; }
        
        public ListaSectionVm(Section filtro, IEnumerable<Section> listaAgent, IEnumerable<Speech> listaSpeech)
        {
            Filtro = filtro;
            Elementos = listaAgent;
            Speechs = listaSpeech.GenerarLista(true);
        }
    }
}