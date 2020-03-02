using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult ReporteBusiness()
        {
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            List<KeyValuePair<string, string>> lstEnterpriseBE = objEnterpriseBL.EmpresaListarCombo();

            ViewData["lstEnterpriseBE"] = lstEnterpriseBE;

            return View();
        }

        //Combos Oficina
        public async Task<JsonResult> OficinaListarCombos(Enterprise objEnterpriseBE)
        {
            OfficeLogica objofficeBL = new OfficeLogica();
            List<KeyValuePair<string, string>> lstOpcionBE = await objofficeBL.OficinaListarCombos(objEnterpriseBE);
            return Json(lstOpcionBE, JsonRequestBehavior.AllowGet);
        }

        //Combos SubOficina
        public async Task<JsonResult> SubOficinaListarCombos(Office objOficinaBE)
        {
            SubOfficeLogica objSubOfficeBL = new SubOfficeLogica();
            List<KeyValuePair<string, string>> lstOpcionBE = await objSubOfficeBL.SubOficinaListarCombos(objOficinaBE);
            return Json(lstOpcionBE, JsonRequestBehavior.AllowGet);
        }

        //Combos Negocio
        public async Task<JsonResult> NegocioListarCombos(SubOffice objSubOficinaBE)
        {
            BusinessLogica objBusinessBL = new BusinessLogica();
            List<KeyValuePair<string, string>> lstOpcionBE = await objBusinessBL.NegocioListarCombos(objSubOficinaBE);
            return Json(lstOpcionBE, JsonRequestBehavior.AllowGet);
        }

        //Combos Speech
        public async Task<JsonResult> SpeechListarCombos(Business objNegocioBE)
        {
            SpeechLogica objSpeechBL = new SpeechLogica();
            List<KeyValuePair<string, string>> lstOpcionBE = await objSpeechBL.SpeechListarCombos(objNegocioBE);
            return Json(lstOpcionBE, JsonRequestBehavior.AllowGet);
        }


        //Reportes
        public async Task<JsonResult> NegocioRegistrar(Business objNegocioBE)
        {
            bool resultado = false;
            BusinessLogica objBusinessBL = new BusinessLogica();
            resultado = await objBusinessBL.NegocioRegistrar(objNegocioBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> NegocioEliminar(Business objNegocioBE)
        {
            bool resultado = false;
            BusinessLogica objBusinessBL = new BusinessLogica();
            resultado = await objBusinessBL.NegocioEliminar(objNegocioBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> NegocioListar(Business objNegocioBE)
        {
            List<Business> resultado = new List<Business>();
            BusinessLogica objBusinessBL = new BusinessLogica();
            resultado = await objBusinessBL.NegocioListar(objNegocioBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //public async Task<JsonResult> ListarAudioSpeech(Speech objSpeechBE)
        //{
        //    SpeechLogica oSpeechLogica = new SpeechLogica();
        //    var lstReporteBE = await oSpeechLogica.ListarAudioSpeech(objSpeechBE);
        //    return Json(lstReporteBE, JsonRequestBehavior.AllowGet);
        //}

        //public async Task<JsonResult> ListarAudioDetalle(AudioWts objAudio)
        //{
        //    SpeechLogica oSpeechLogica = new SpeechLogica();
        //    var lstReporteBE = await oSpeechLogica.ListarAudioDetalle(objAudio);
        //    return Json(lstReporteBE, JsonRequestBehavior.AllowGet);
        //}
    }
}