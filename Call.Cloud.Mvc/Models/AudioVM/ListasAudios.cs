using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Modelo;
using System.Web.Mvc;
using AutoMapper;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Models.AudioVM
{
    public class ListasAudios
    {

        public AudioVm Filtro { get; set; }
        public IEnumerable<AudioVm> Elementos { get; set; }
        public IEnumerable<SelectListItem> audios { get; set; }
        public IEnumerable<SelectListItem> Boss { get; set; }
        public IEnumerable<SelectListItem> Agent { get; set; }
        public IEnumerable<SelectListItem> Business { get; set; }
        public ListasAudios(AudioVm filtro, IEnumerable<AudioVm> listaAudios,
            IEnumerable<Agent> Supervisor, IEnumerable<Agent> Agentes, 
            IEnumerable<Business> Negocio)
        {
            Filtro = filtro;
            Elementos = listaAudios;
            Boss = Supervisor.GenerarLista(true);
            Agent = Agentes.GenerarLista(true);
            Business = Negocio.GenerarLista(true);
        }

    }
}