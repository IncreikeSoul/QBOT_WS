using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.Models.BlackListVM;
using Call.Cloud.Modelo;
using Call.Cloud.Logica;

/* Seguridad */
using Call.Cloud.Mvc.Models.Acount;
using Call.Cloud.Mvc.Controllers.Shared;
/* Fin Seguridad */

namespace Call.Cloud.Mvc.Controllers
{
    public class BlackListController : ApplicationController<LogOnModel>
    {
        // GET: BlackList

        public async Task<ActionResult> Index(string respuesta = "")
        {
            LogOnModel sessionModel = GetLogOnSessionModel();
            if (sessionModel is null)
            {
                return RedirectToAction("Login_User");
            }
            else
            {
                ViewBag.Mensaje = respuesta;
                return View(await CrearModelo());
            }
        }

        private async Task<ListaBlakListVm> CrearModelo(BlackList Item = null)
        {
            BlackListLogica blacklogica = new BlackListLogica();
            EnterpriseLogica enterlogica = new EnterpriseLogica();
            if (Item == null)
                  Item = new BlackList();
            var listablack = await blacklogica.Retrieve(Item);
            return new ListaBlakListVm(Item,listablack);
         }

        private async Task<ListaBlakListVm> Busqueda2(BlackList Item = null)
        {
            BlackListLogica whitelogica = new BlackListLogica();
            EnterpriseLogica enterlogica = new EnterpriseLogica();
            if (Item == null)
                Item = new BlackList();
            var busqueda = await whitelogica.Buscar(Item);
            return new ListaBlakListVm(Item, busqueda);
        }


        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Buscar(BlackList filtro)
        {
            return View("Grid", await Busqueda2(filtro));
        }

        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            BlackListLogica blacklogica = new BlackListLogica();
            EnterpriseLogica enterlogica = new EnterpriseLogica();

            var item = (id == -1) ? new BlackList() : await blacklogica.Find(new BlackList
            {
                pk = id
            });
            var listaEnterprise = await enterlogica.Retrieve(null);
            return View(new EditarBlackListVm(item,listaEnterprise));
        }

        [HttpPost]
        public async Task<ActionResult> Editar(BlackList Item)
        {
            string mensajeRespuesta = "";
            BlackListLogica blacklogica = new BlackListLogica();
            var rpta = await blacklogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "BlackList", new { respuesta = mensajeRespuesta });
        }

        public async Task<ActionResult> Eliminar(int id)
        {
            string mensajeRespuesta = "";
            BlackListLogica blacklogica = new BlackListLogica();
            var rpta = await blacklogica.Delete(new BlackList
            {
                pk = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "BlackList", new { respuesta = mensajeRespuesta });

        }




    }
}