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