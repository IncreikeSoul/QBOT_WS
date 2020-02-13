using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.Models.AgentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Controllers
{
    public class AgentController : Controller
    {
        // GET: Agent
        public async Task<ActionResult> Index(string respuesta="")
        {
            ViewBag.Mensaje = respuesta;
            return View(await CrearModelo());
        }
        private async Task<ListaAgentVm> CrearModelo(Agent Item=null)
        {
            AgentLogica oAgentLogica = new AgentLogica();
            BusinessLogica oBussinesLogica = new BusinessLogica();
            if (Item == null)
                Item = new Agent();            
            var listaAgent =  await oAgentLogica.Retrieve(Item);
            var listaBussines = await oBussinesLogica.Retrieve(null);
            
            return new ListaAgentVm(Item, listaAgent, listaBussines);
        }

              
        public async Task<ActionResult> Buscar(Agent filtro)
        {
            return View("Grid", await CrearModelo(filtro));
        }

        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            AgentLogica oAgentLogica = new AgentLogica();
            BusinessLogica oBussinesLogica = new BusinessLogica();

            var item = (id == -1) ? new Agent() : await oAgentLogica.Find(new Agent
            {
                PkAgent = id
            });
            var listaSubOffice = await oBussinesLogica.Retrieve(null);

            /* Listado de Jefes */
            AgentLogica ol = new AgentLogica();
            var ListaJefes = await ol.RetrieveBoss(new Agent());
            
            return View(new EditarAgentVm(item, listaSubOffice, ListaJefes));
        }

        //[HttpGet]
        public async Task<ActionResult> BuscarJefe(int pk_Business)
        {
            AgentLogica ol = new AgentLogica();
            var ListaJefes = await ol.RetrieveBoss(new Agent());

            return Json(ListaJefes);
        }

        [HttpPost]
        public async Task <ActionResult> Editar(Agent Item)
        {
            string mensajeRespuesta = "";
            AgentLogica oAgentLogica = new AgentLogica();
            var rpta= await oAgentLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "Agent", new { respuesta = mensajeRespuesta });
            
        }

        public async Task<ActionResult> Eliminar(int id)
        {
            string mensajeRespuesta = "";
            AgentLogica oAgentLogica = new AgentLogica();
            var rpta = await oAgentLogica.Delete(new Agent
            {
                PkAgent=id
            });
            
            if (rpta>0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "Agent", new { respuesta = mensajeRespuesta });

        }
    }
}