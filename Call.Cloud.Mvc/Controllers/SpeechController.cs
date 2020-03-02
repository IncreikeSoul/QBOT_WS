using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.Models.SpeechVM;
using System.Threading.Tasks;
using System.Web.Mvc;

/* Seguridad */
using Call.Cloud.Mvc.Models.Acount;
using Call.Cloud.Mvc.Controllers.Shared;
/* Fin Seguridad */

namespace Call.Cloud.Mvc.Controllers
{
    public class SpeechController : ApplicationController<LogOnModel>
    {
        #region Mantenimiento
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

        private async Task<ListaSpeechVm> CrearModelo(Speech Item = null)
        {
            Section section = new Section();
            SpeechLogica OSpeechLogica = new SpeechLogica();
            SectionLogica OSectionLogica = new SectionLogica();
            
            BusinessLogica oBusinessLogica = new BusinessLogica();
            if (Item == null)
                Item = new Speech();
            
            var listaSpeech = await OSpeechLogica.Retrieve(Item);
            Business oBusiness = new Business();
            var listaBussines = await oBusinessLogica.Retrieve(oBusiness);
            var listaSecciones = await OSectionLogica.Retrieve(section);
            return new ListaSpeechVm(Item, listaSpeech, listaBussines,listaSecciones);
        }

        
        public async Task<ActionResult> Buscar(Speech filtro)
        {
            return View("Grid", await CrearModelo(filtro));
        }

        //[HttpGet]
        //public async Task<ActionResult> Editar(int id)
        //{
        //    SpeechLogica OSpeechLogica = new SpeechLogica();
        //    BusinessLogica oBusinessLogica = new BusinessLogica();
        //    var item = (id == -1) ? new Speech() : await OSpeechLogica.Find(new Speech
        //    {
        //        PkSpeech = id
        //    });
        //    Business oBusiness = new Business();
        //    var listaSubOffice = await oBusinessLogica.Retrieve(oBusiness);
        //    return View(new EditarSpeechVm(item, listaSubOffice));
        //}

        [HttpPost]
        public async Task<ActionResult> Editar(Speech Item)
        {
#pragma warning disable CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            string mensajeRespuesta = "";
#pragma warning restore CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            SpeechLogica OSpeechLogica = new SpeechLogica();
            var rpta = await OSpeechLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "Speech");
        }

        //public async Task<ActionResult> Eliminar(int id)
        //{
        //    string mensajeRespuesta = "";
        //    SpeechLogica OSpeechLogica = new SpeechLogica();
        //    var rpta = await OSpeechLogica.Delete(new Speech
        //    {
        //        PkSpeech = id
        //    });

        //    if (rpta > 0)
        //        mensajeRespuesta = "Se eliminó correctamente el registro";
        //    else
        //        mensajeRespuesta = "Ocurrió un error";
        //    return RedirectToAction("Index", "Speech");
        //}
        #endregion

        //public async Task<ActionResult> SectionBySpeech(int id, string name="", string sectionname="", int PkSection=0)
        //{
        //    LogOnModel sessionModel = GetLogOnSessionModel();
        //    if (sessionModel is null)
        //    {
        //        return RedirectToAction("Login_User");
        //    }
        //    else
        //    {
        //        SpeechLogica oSpeechLogica = new SpeechLogica();

        //        Session["PkSpeech"] = id;
        //        Session["SpeechName"] = name;
        //        Session["SectionName"] = "";
        //        Session["PkSection"] = PkSection;
        //        ViewBag.Section = PkSection;
        //        ViewBag.nombreSection = sectionname;
        //        ViewBag.nombrespeech = name;

        //        var listaSecciones = await oSpeechLogica.RetrieveSectionSpeech(id);
        //        return View("SectionBySpeech", listaSecciones);
        //    }
        //}
        public async Task<JsonResult> ListarSpeech(Speech objSpeechBE)
        {
            SpeechLogica oSpeechLogica = new SpeechLogica();
            var lstSpeechBE = await oSpeechLogica.SpeechListar(objSpeechBE);// Retrieve(objSpeechBE);
            return Json(lstSpeechBE, JsonRequestBehavior.AllowGet);
        }
    }
}