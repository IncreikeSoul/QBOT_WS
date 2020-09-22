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
    public class EnterpriseController : Controller
    {
        // GET: Enterprise
        //public ActionResult RegistrarFTP()
        //{
        //    EnterpriseLogica objEnterpriseBE = new EnterpriseLogica();
        //    List<Enterprise> lstEnterpriseBE =  objEnterpriseBE.Listar();
        //    ViewData["lstEnterpriseBE"] = lstEnterpriseBE;
        //    return View();
        //}

        public async Task<ActionResult> EjecutarSTT()
        {
            AgentLogica oAgentLogica = new AgentLogica();
            SpeechLogica oSpeechLogica = new SpeechLogica();
            BusinessLogica oBussinesLogica = new BusinessLogica();
            EnterpriseLogica objEnterpriseBE = new EnterpriseLogica();
            
            //List<Enterprise> lstEnterpriseBE = objEnterpriseBE.Listar();
            //ViewData["lstEnterpriseBE"] = lstEnterpriseBE;
            Agent oAgentBE = new Agent();
            Speech oSpeechBE = new Speech();
            Business oBusinessBE = new Business();
            EnterpriseFTPDatos enterpriseFTPDatos = new EnterpriseFTPDatos();
            var listaAgent = await oAgentLogica.Retrieve(oAgentBE);
            var listaBussines = await oBussinesLogica.RetrieveActive(oBusinessBE);
            var listaSpeach = await oSpeechLogica.SpeechListar(oSpeechBE);
            var listarFtp = await objEnterpriseBE.ListarFTP(enterpriseFTPDatos);
            ViewData["listaAgent"] = listaAgent;
            ViewData["listaBussines"] = listaBussines;
            ViewData["listaSpeach"] = listaSpeach;
            ViewData["listarFtp"] = listarFtp;
            return View();
        }

        public async Task<JsonResult> GuardarFTP(EnterpriseFTPDatos objEnterpriseFTP)
        {
            bool resultado = false;
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            resultado = await objEnterpriseBL.GuardarFTP(objEnterpriseFTP);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> ListarFTP(EnterpriseFTPDatos objEnterpriseFTP)
        {
            List<EnterpriseFTPDatos> resultado = new List<EnterpriseFTPDatos>();
            EnterpriseLogica objEnterpriseBL = new EnterpriseLogica();
            resultado = await objEnterpriseBL.ListarFTP(objEnterpriseFTP);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}