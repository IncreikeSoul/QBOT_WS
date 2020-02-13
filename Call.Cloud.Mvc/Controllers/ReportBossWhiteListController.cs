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
    public class ReportBossWhiteListController : Controller
    {
        // GET: ReportBossWhiteList
        public async Task<ActionResult> ReportBossWhiteList()
        {
            return View(await CrearModelo ());
        }
        public async Task<JsonResult>chart_whiteList_Boss_year(ReportVmBoss filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Year_Boos(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_whiteList_Boss_Month(ReportVmBoss filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_month_Boss(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult>chart_whiteList_Boss_Day(ReportVmBoss filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Day_Boss(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_whiteList_Boss_Year_Organizational(ReportVmBoss filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Year_Boos_Organizational(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }


        private async Task<ListaReportBoss> CrearModelo(ReportVmBoss Item = null)
        {
            Business Item1 = new Business();
            Reporte01 rp = new Reporte01();
            BusinessLogica le = new BusinessLogica();
            if (Item == null)
                Item = new ReportVmBoss();
            var listaAgent = await rp.graph_Year_Boos(Item);
            var listasubOffice = await le.Retrieve(Item1);
            return new ListaReportBoss(Item, listaAgent, listasubOffice);
        }
    }
}