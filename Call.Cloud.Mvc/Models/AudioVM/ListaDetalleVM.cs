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
    public class ListaDetalleVM
    {
        public AudioVm Filtro { get; set; }
        public IEnumerable<AudioVm> Elementos { get; set; }
        public IEnumerable<SelectListItem> audios { get; set; }
        public ListaDetalleVM(AudioVm filtro, IEnumerable<AudioVm> listaAudios)
        {
            Filtro = filtro;
            Elementos = listaAudios;
        }
    }
}