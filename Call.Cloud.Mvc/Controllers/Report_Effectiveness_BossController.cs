using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Mvc.Models.Effectiveness;
using System.Threading.Tasks;

/* Seguridad */
using Call.Cloud.Mvc.Models.Acount;
using Call.Cloud.Mvc.Controllers.Shared;
/* Fin Seguridad */

namespace Call.Cloud.Mvc.Controllers
{
    public class Report_Effectiveness_BossController : ApplicationController<LogOnModel>
    {
        // GET: Report_Effectiveness_Boss
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

        private async Task<ListaReportBoss> CrearModelo(ReportsVm Item = null)
        {
            Reporte_Eficacia eficacia = new Reporte_Eficacia();
            BusinessLogica ol = new BusinessLogica();

            if (Item == null)
                Item = new ReportsVm();
            var listareport = await eficacia.Chart_Boss_Year_Vertical(Item);
            var listabusiness = await ol.RetrieveActive(new Business());

            return new ListaReportBoss(Item, listareport, listabusiness);
        }

        //Chart_Year_Boss_Verticalmente
        public async Task<JsonResult> Chart_Boss_Year_Vertical(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.Chart_Boss_Year_Vertical(filtro);

            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //Chart_Month_Boss
        public async Task<JsonResult> Chart_Boss_Month(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.Chart_Boss_Month(filtro);

            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //Chart_Day_Boss
        public async Task<JsonResult> Chart_Boss_Day(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.Chart_Boss_Day(filtro);

            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //Chart_Year_Agent
        public async Task<JsonResult> Chart_Agent_Year(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.Chart_Agent_Year(filtro);

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
        //boss por año
        public async Task<JsonResult> Report_Effectiveness_Year(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.graph_Year_Boos(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);

        }

        //boss por mes
        public async Task<JsonResult> Report_Effectiveness_Month(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.graph_month_Boss(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        //boss por dia
        public async Task<JsonResult> Report_Effectiveness_Day(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = await rp.graph_Day_Boss(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

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

        //name_Rule
        public async Task<JsonResult> NameRule(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var list_rule = await rp.name_rule(filtro);
            return Json(list_rule, JsonRequestBehavior.AllowGet);
        }

        //dinamico
        //supervisor
        //año
        public JsonResult dinamico0001(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = rp.obetner_name_columns01(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        //mes
        public JsonResult dinamico_Boss_Month(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = rp.report_Boss_Month(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        //dia
        public JsonResult dinamico_Boss_Day(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var datachart = rp.report_Boss_Day_dinamico(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        //nombres de la regla
        public async Task<JsonResult> name_rules(ReportsVm filtro)
        {
            Reporte_Eficacia rp = new Reporte_Eficacia();
            var name_rule = await rp.name_rule(filtro);
            return Json(name_rule, JsonRequestBehavior.AllowGet);
        }

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
    }
}