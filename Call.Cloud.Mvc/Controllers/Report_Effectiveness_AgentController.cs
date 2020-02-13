using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.Models.Effectiveness;
using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Modelo;
using Call.Cloud.Logica;

/* Seguridad */
using Call.Cloud.Mvc.Models.Acount;
using Call.Cloud.Mvc.Controllers.Shared;
/* Fin Seguridad */

namespace Call.Cloud.Mvc.Controllers
{
    public class Report_Effectiveness_AgentController : ApplicationController<LogOnModel>
    {
        // GET: Report_Effectiveness_Agent
        public async Task<ActionResult> Index()
        {
            LogOnModel sessionModel = GetLogOnSessionModel();
            if (sessionModel is null)
            {
                return RedirectToAction("Login_User");
            }
            else
            {
                return View(await CrearModelo());
            }
        }

        private async Task<ListaReportAgent> CrearModelo(ReportsVm Item = null)
        {
            Reporte_Eficacia eficacia = new Reporte_Eficacia();
            //BossLogica ol = new BossLogica();
            AgentLogica ol = new AgentLogica();

            if (Item == null)
                Item = new ReportsVm();
            var listareport = await eficacia.Chart_Agent_Year_Vertical(Item);
            var listaboss = await ol.RetrieveBoss(new Agent());

            return new ListaReportAgent(Item, listareport, listaboss);
        }

        //Chart_Year_Agent_Verticalmente
        public async Task<JsonResult> Chart_Agent_Year_Vertical(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.Chart_Agent_Year_Vertical(filtro);

            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //Chart_Month_Agent
        public async Task<JsonResult> Chart_Agent_Month(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.Chart_Agent_Month(filtro);

            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //Chart_Day_Agent
        public async Task<JsonResult> Chart_Agent_Day(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.Chart_Agent_Day(filtro);

            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //Chart_Day_Agent
        public async Task<JsonResult> Agent_LLamada(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.Agent_LLamada(filtro);

            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //Segmentado        
        //agente por año
        public async Task<JsonResult> Agent_Year(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.graph_Year_Agent(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //agente por mes
        public async Task<JsonResult> Agent_Month(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.graph_Month_Agent(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //agente por dia
        public async Task<JsonResult> Agent_Day(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.graph_Day_Agent(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //agente organizacional
        public async Task<JsonResult> Report_Effectiveness_Year_organizational(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachat = await rp.graph_Year_Agent_Organizational(filtro);
            return Json(datachat, JsonRequestBehavior.AllowGet);
        }

        //agente por llamada
        public async Task<JsonResult> Report_Agent_call(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.Agent_LLamad(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //dinamico
        //agente 
        //año
        public JsonResult dinamico_agent_Year(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = rp.report_agent_year(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        //mes
        public JsonResult dinamico_agent_Month(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = rp.report_agent_month(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        //dia
        public JsonResult dinamico_Agent_Day(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = rp.report_agent_day(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        //llamada
        public JsonResult dinamico_Agent_Call(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = rp.report_agent_call(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public JsonResult list_IDBusiness_agent()
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var IDBusiness = rp.list_IDBusiness();
            return Json(IDBusiness, JsonRequestBehavior.AllowGet);
        }
    }
}