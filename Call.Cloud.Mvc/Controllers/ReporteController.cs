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

        public async Task<JsonResult> ReporteListar(AudioEva objAudioBE)
        {
            List<AudioEva> resultado = new List<AudioEva>();
            AudioLogica objAudioBL = new AudioLogica();
            resultado = await objAudioBL.AudioListar(objAudioBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> EvaluacionSectionListar(Evaluacion objEvalBE)
        {
            List<Evaluacion> resultado = new List<Evaluacion>();
            AudioLogica objAudioBL = new AudioLogica();
            resultado = await objAudioBL.EvaluacionSectionListar(objEvalBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> EvaluacionRulesListar(Evaluacion objEvalBE)
        {
            List<Evaluacion> resultado = new List<Evaluacion>();
            AudioLogica objAudioBL = new AudioLogica();
            resultado = await objAudioBL.EvaluacionRulesListar(objEvalBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> EvaluacionDiccionarioListar()
        {
            List<Evaluacion> resultado = new List<Evaluacion>();
            AudioLogica objAudioBL = new AudioLogica();
            resultado = await objAudioBL.EvaluacionDiccionarioListar();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}