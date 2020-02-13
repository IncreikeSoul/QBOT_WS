using Call.Cloud.AccesoDatos;
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
    public class MantenimientoController : Controller
    {
        // GET: Empresa
        public ActionResult Empresa()
        {
            return View();
        }

        // GET: Oficina
        public ActionResult Oficina()
        {
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            List<KeyValuePair<string, string>> lstEnterpriseBE = objEnterpriseBL.EmpresaListarCombo();

            ViewData["lstEnterpriseBE"] = lstEnterpriseBE;
            return View();
        }

        // GET: SubOficina
        public ActionResult SubOficina()
        {
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            List<KeyValuePair<string, string>> lstEnterpriseBE = objEnterpriseBL.EmpresaListarCombo();

            ViewData["lstEnterpriseBE"] = lstEnterpriseBE;
            return View();
        }

        // GET: Negocio
        public ActionResult Negocio()
        {
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            List<KeyValuePair<string, string>> lstEnterpriseBE = objEnterpriseBL.EmpresaListarCombo();

            ViewData["lstEnterpriseBE"] = lstEnterpriseBE;
            return View();
        }

        // GET: Speech
        public ActionResult Speech()
        {
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            List<KeyValuePair<string, string>> lstEnterpriseBE = objEnterpriseBL.EmpresaListarCombo();

            ViewData["lstEnterpriseBE"] = lstEnterpriseBE;
            return View();
        }

        // GET: Seccion
        public ActionResult Seccion()
        {
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            List<KeyValuePair<string, string>> lstEnterpriseBE = objEnterpriseBL.EmpresaListarCombo();

            ViewData["lstEnterpriseBE"] = lstEnterpriseBE;
            return View();
        }

        /***************************************************/
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

        //Combos Section
        public async Task<JsonResult> SectionListarCombos(Speech objSpeechBE)
        {
            SectionLogica objSectionBL = new SectionLogica();
            List<KeyValuePair<string, string>> lstOpcionBE = await objSectionBL.SectionListarCombos(objSpeechBE);
            return Json(lstOpcionBE, JsonRequestBehavior.AllowGet);
        }

        /**************************************************/
        //Empresa
        public async Task<JsonResult> EmpresaRegistrar(Enterprise objEnterpriseBE)
        {
            bool resultado = false;
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            resultado = await objEnterpriseBL.EmpresaRegistrar(objEnterpriseBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> EmpresaEliminar(Enterprise objEnterpriseBE)
        {
            bool resultado = false;
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            resultado = await objEnterpriseBL.EmpresaEliminar(objEnterpriseBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> EmpresaListar(Enterprise objEnterpriseBE)
        {
            List<Enterprise> resultado = new List<Enterprise>();
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            resultado = await objEnterpriseBL.EmpresaListar(objEnterpriseBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //Oficina
        public async Task<JsonResult> OficinaRegistrar(Office objOfficeBE)
        {
            bool resultado = false;
            OfficeLogica objOfficeBL = new OfficeLogica();
            resultado = await objOfficeBL.OficinaRegistrar(objOfficeBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> OficinaEliminar(Office objOfficeBE)
        {
            bool resultado = false;
            OfficeLogica objOfficeBL = new OfficeLogica();
            resultado = await objOfficeBL.OficinaEliminar(objOfficeBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> OficinaListar(Office objOfficeBE)
        {
            List<Office> resultado = new List<Office>();
            OfficeLogica objOfficeBL = new OfficeLogica();
            resultado = await objOfficeBL.OficinaListar(objOfficeBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //Sub Oficina
        public async Task<JsonResult> SubOficinaRegistrar(SubOffice objSubOfficeBE)
        {
            bool resultado = false;
            SubOfficeLogica objSubOfficeBL = new SubOfficeLogica();
            resultado = await objSubOfficeBL.SubOficinaRegistrar(objSubOfficeBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SubOficinaEliminar(SubOffice objSubOfficeBE)
        {
            bool resultado = false;
            SubOfficeLogica objSubOfficeBL = new SubOfficeLogica();
            resultado = await objSubOfficeBL.SubOficinaEliminar(objSubOfficeBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SubOficinaListar(SubOffice objSubOfficeBE)
        {
            List<SubOffice> resultado = new List<SubOffice>();
            SubOfficeLogica objSubOfficeBL = new SubOfficeLogica();
            resultado = await objSubOfficeBL.SubOficinaListar(objSubOfficeBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //Negocio
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


        //Speech
        public async Task<JsonResult> SpeechRegistrar(Speech objSpeechBE)
        {
            bool resultado = false;
            SpeechLogica objSpeechBL = new SpeechLogica();
            resultado = await objSpeechBL.SpeechRegistrar(objSpeechBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SpeechEliminar(Speech objSpeechBE)
        {
            bool resultado = false;
            SpeechLogica objSpeechBL = new SpeechLogica();
            resultado = await objSpeechBL.SpeechEliminar(objSpeechBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SpeechListar(Speech objSpeechBE)
        {
            List<Speech> resultado = new List<Speech>();
            SpeechLogica objSpeechBL = new SpeechLogica();
            resultado = await objSpeechBL.SpeechListar(objSpeechBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //Seccion
        public async Task<JsonResult> SeccionRegistrar(Section objSeccionBE)
        {
            bool resultado = false;
            SectionLogica objSeccionBL = new SectionLogica();
            resultado = await objSeccionBL.SeccionRegistrar(objSeccionBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SeccionEliminar(Section objSeccionBE)
        {
            bool resultado = false;
            SectionLogica objSeccionBL = new SectionLogica();
            resultado = await objSeccionBL.SeccionEliminar(objSeccionBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SeccionListar(Section objSeccionBE)
        {
            List<Section> resultado = new List<Section>();
            SectionLogica objSeccionBL = new SectionLogica();
            resultado = await objSeccionBL.SeccionListar(objSeccionBE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}