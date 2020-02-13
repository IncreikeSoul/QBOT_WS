using AutoMapper;
using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Models.AgentVM
{
    public class EditarAgentVm
    {
        public Agent Item { get; set; }
        public IEnumerable<SelectListItem> Bussines { get; set; }
        public IEnumerable<SelectListItem> Agent { get; set; }
        public EditarAgentVm(Agent item, IEnumerable<Business> bussines, IEnumerable<Agent> agent)
        {
            Item = item;
            Bussines = bussines.GenerarLista();
            Agent = agent.GenerarLista();
        }
    }
}