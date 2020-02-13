using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Mvc.Models.ReportsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.Models.OfficeVM;

namespace Call.Cloud.Mvc.Controllers
{
    public class OfficeController : Controller
    {
        // GET: Office
        //public async Task<ActionResult> Index()
        //{
        //    return View(await CrearModelo1());
        //}


        public async Task<JsonResult> ListarOficinas(Office objOfficeBE)
        {
            OfficeLogica oOfficeLogica = new OfficeLogica();
            var lstOfficeBE = await oOfficeLogica.OficinaListar(objOfficeBE);
            return Json(lstOfficeBE, JsonRequestBehavior.AllowGet);
        }

        //private async Task<ListaOfficeVm> CrearModelo1(Office Item = null)
        //{
        //    OfficeLogica oOfficeLogica = new OfficeLogica();
        //    EnterpriseLogica le = new EnterpriseLogica();
        //    if (Item == null)
        //        Item = new Office();
        //    var listaOffice = await oOfficeLogica.Retrieve(Item);
        //    var enterprise = await le.Retrieve(null);

        //    return new ListaOfficeVm(Item, listaOffice, enterprise);
        //}
        
        //public async Task<ActionResult> Buscar(Office filtro)
        //{
        //    return View("Grid", await CrearModelo1(filtro));
        //}

        //[HttpGet]
        //public async Task<ActionResult> Editar(int id)
        //{
        //    OfficeLogica oSubOfficeLogica = new OfficeLogica();
        //    EnterpriseLogica oOfficeLogica = new EnterpriseLogica();

        //    var item = (id == -1) ? new Office() : await oSubOfficeLogica.Find(new Office
        //    {
        //        PkOffice = id
        //    });
        //    //??
        //    var listaBusiness = await oOfficeLogica.Retrieve(null);
        //    return View(new EditarOfficeVm(item, listaBusiness));
        //}

        //[HttpPost]

        //public async Task<ActionResult> Editar(Office Item)
        //{
        //    string mensajeRespuesta = "";
        //    OfficeLogica oSubOfficeLogica = new OfficeLogica();
        //    var rpta = await oSubOfficeLogica.Edit(Item);
        //    if (rpta == 2)
        //        mensajeRespuesta = "Se modificó correctamente el registro";
        //    else if (rpta == 1)
        //        mensajeRespuesta = "Se agregó correctamente el registro";
        //    else
        //        mensajeRespuesta = "Ocurrió un error";

        //    return RedirectToAction("Index", "Office", new { respuesta = mensajeRespuesta });

        //}

        //public async Task<ActionResult> Eliminar(int id)
        //{
        //    string mensajeRespuesta = "";
        //    OfficeLogica oSubOfficeLogica = new OfficeLogica();
        //    var rpta = await oSubOfficeLogica.Delete(new Office
        //    {
        //        PkOffice = id
        //    });

        //    if (rpta > 0)
        //        mensajeRespuesta = "Se eliminó correctamente el registro";
        //    else
        //        mensajeRespuesta = "Ocurrió un error";

        //    return RedirectToAction("Index", "Office", new { respuesta = mensajeRespuesta });

        //}

        //private async Task<ListaReportOffice> CrearModelo(ReportVmOffice Item = null)
        //{
        //    Enterprise Item1 = new Enterprise();
        //    Reporte rp = new Reporte();
        //    Reporte rl = new Reporte();
        //    EnterpriseLogica le = new EnterpriseLogica();
        //    if (Item == null)
        //        Item = new ReportVmOffice();
        //    var listaEnterprise = await le.Retrieve(Item1);
        //    var datos_enterprise = await rl.grafica01(Item);
        //    return new ListaReportOffice(Item, datos_enterprise, listaEnterprise);
        //}
    }
}