using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.Models.SubOfficeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Controllers
{
    public class SubOfficeController : Controller
    {
        // GET: SubOffice
        public async Task<ActionResult> Index(string respuesta = "")
        {
            ViewBag.Mensaje = respuesta;
            return View(await CrearModelo());
        }

        private async Task<ListaSubOfficeVm> CrearModelo(SubOffice Item = null)
        {
            SubOfficeLogica oSubOfficeLogica = new SubOfficeLogica();
            OfficeLogica oOfficeLogica = new OfficeLogica();
            if (Item == null)
                Item = new SubOffice();
            var listaSubOffice = await oSubOfficeLogica.Retrieve(Item);
            var listaOffice = await oOfficeLogica.Retrieve(null);

            return new ListaSubOfficeVm(Item, listaSubOffice, listaOffice);
        }

        public async Task<ActionResult> Buscar(SubOffice filtro)
        {
            return View("Grid", await CrearModelo(filtro));
        }

        //[HttpGet]
        //public async Task<ActionResult> Editar(int id)
        //{
        //    SubOfficeLogica oSubOfficeLogica = new SubOfficeLogica();
        //    OfficeLogica oOfficeLogica = new OfficeLogica();

        //    var item = (id == -1) ? new SubOffice() : await oSubOfficeLogica.Find(new SubOffice
        //    {
        //        PkSubOffice = id
        //    });
        //    var listaBusiness = await oOfficeLogica.Read(null);
        //    return View(new EditarSubOfficeVm(item, listaBusiness));
        //}

        [HttpPost]
        public async Task<ActionResult> Editar(SubOffice Item)
        {
            string mensajeRespuesta = "";
            SubOfficeLogica oSubOfficeLogica = new SubOfficeLogica();
            var rpta = await oSubOfficeLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "SubOffice", new { respuesta = mensajeRespuesta });

        }

        //public async Task<ActionResult> Eliminar(int id)
        //{
        //    string mensajeRespuesta = "";
        //    SubOfficeLogica oSubOfficeLogica = new SubOfficeLogica();
        //    var rpta = await oSubOfficeLogica.Delete(new SubOffice
        //    {
        //        PkSubOffice = id
        //    });

        //    if (rpta > 0)
        //        mensajeRespuesta = "Se eliminó correctamente el registro";
        //    else
        //        mensajeRespuesta = "Ocurrió un error";

        //    return RedirectToAction("Index", "SubOffice", new { respuesta = mensajeRespuesta });

        //}

        public async Task<JsonResult> ListarSubOficinas(SubOffice objSubOfficeBE)
        {
            SubOfficeLogica oSubOfficeLogica = new SubOfficeLogica();
            var lstSubOfficeBE = await oSubOfficeLogica.SubOficinaListar(objSubOfficeBE);// Retrieve(objSubOfficeBE);
            return Json(lstSubOfficeBE, JsonRequestBehavior.AllowGet);
        }
    }
}