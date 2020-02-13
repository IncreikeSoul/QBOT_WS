using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Mvc.Models.ReportsVM;
using System.Threading.Tasks;
using Call.Cloud.Modelo;
using Call.Cloud.Logica;

namespace Call.Cloud.Mvc.Controllers
{
    public class ReportAgentController : Controller
    {
        // GET: ReportAgent
        public  async Task<ActionResult> ReportAgent()
        {
            return View(await CrearModelo());
        }

        public ActionResult Prueba()
        {
            return View();
        }
        
        public async Task<JsonResult>chart_Agent_Year(ReportVmAgent filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.graph_Year_Agent(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult>chart_Agent_Month(ReportVmAgent filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.graph_Month_Agent(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult>chart_Agent_Day(ReportVmAgent filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.graph_Day_Agent(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_Agent_Year__Organizational(ReportVmAgent filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.graph_Year_Agent_Organizational(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> Report_Call(ReportVmAgent filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.Agent_LLamad(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        private async Task<ListaReportAgent> CrearModelo(ReportVmAgent Item = null)
        {
            Agent Item1 = new Agent();
            Reporte rl = new Reporte();
            AgentLogica le = new AgentLogica();
            if (Item == null)
                Item = new ReportVmAgent();
            var listaEnterprise = await le.Retrieve(Item1);
            var datos_enterprise = await rl.graph_Year_Agent(Item);
            return new ListaReportAgent(Item, datos_enterprise, listaEnterprise);
        }
    }
}