using AutoMapper;
using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;
namespace Call.Cloud.Mvc.Models.RuleVM
{
    public class ListaRuleVm
    {
        public Rule Filtro { get; set; }
        public IEnumerable<Rule> Elementos { get; set; }
        public IEnumerable<SelectListItem> Secciones { get; set; }

        public ListaRuleVm(Rule filtro, IEnumerable<Rule> listaAgent, IEnumerable<Section> secciones)
        {
            Filtro = filtro;
            Elementos = listaAgent;
            Secciones = secciones.GenerarLista(true);
        }
    }
}