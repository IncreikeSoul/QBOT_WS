using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.Models.ReportVM01;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System.Threading.Tasks;
using Call.Cloud.Logica;
using Call.Cloud.Modelo;

namespace Call.Cloud.Mvc.Controllers
{
    public class ReportAgentWhiteListController : Controller
    {
        // GET: ReportAgentWhiteList
        public async  Task <ActionResult> ReportAgentWhiteList()
        {
            return View( await CrearModelo ());
        }

        public async Task<JsonResult>chart_whiteList_Agent_year(ReportVmAgent filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Year_Agent(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult>chart_whiteList_Agent_Month(ReportVmAgent filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Month_Agent(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);

        }
        public async Task<JsonResult> chart_whiteList_Agent_Day(ReportVmAgent filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Day_Agent(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);

        }

        public async Task<JsonResult> chart_whiteList_Agent_Organizational(ReportVmAgent filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Year_Agent__Organizational(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> report_call(ReportVmAgent filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.Grafica_llamada(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);

        }


        private async Task<ListaReportAgent> CrearModelo(ReportVmAgent Item = null)
        {
            Agent Item1 = new Agent();
            Reporte01 rl = new Reporte01();
            AgentLogica le = new AgentLogica();
            if (Item == null)
                Item = new ReportVmAgent();
            var listaEnterprise = await le.Retrieve(Item1);
            var datos_enterprise = await rl.graph_Year_Agent(Item);
            return new ListaReportAgent(Item, datos_enterprise, listaEnterprise);
        }
    }
}