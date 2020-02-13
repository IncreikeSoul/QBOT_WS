using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Call.Cloud.Modelo;
using System.Web.Mvc;
using AutoMapper;
using Call.Cloud.Mvc.App_Start.Extenciones;
namespace Call.Cloud.Mvc.Models.AgentVM
{
    public class ListaAgentVm
    {
        public Agent Filtro { get; set; }
        public IEnumerable<Agent> Elementos { get; set; }
        public IEnumerable<SelectListItem> Bussines { get; set; }
        public ListaAgentVm(Agent filtro, IEnumerable<Agent> listaAgent,IEnumerable<Business> bussines)
        {
            Filtro = filtro;
            Elementos = listaAgent;
            Bussines = bussines.GenerarLista(true);
        }
    }
}