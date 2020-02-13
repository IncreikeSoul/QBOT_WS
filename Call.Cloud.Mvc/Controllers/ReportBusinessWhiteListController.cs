using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.Models.ReportVM01;
using Call.Cloud.Mvc.App_Start.Extenciones;
using System.Threading.Tasks;
using Call.Cloud.Modelo;
using Call.Cloud.Logica;

namespace Call.Cloud.Mvc.Controllers
{
    public class ReportBusinessWhiteListController : Controller
    {
        // GET: ReportBusinessWhiteList
        public async  Task <ActionResult> ReportBusinessWhiteList()
        {
            return View(await CrearModelo());
        }
        public async Task<JsonResult>chart_whiteLit_Business_Year(ReportVmBusiness filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Year(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult>chart_whiteList_Business_Month(ReportVmBusiness filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Month(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult>chart_whileList_Business_Day(ReportVmBusiness filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Day(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_whiteList_Business_Organizational(ReportVmBusiness filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graph_Year_Business_Organizational(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        private async Task<ListaReportBusiness> CrearModelo(ReportVmBusiness Item = null)
        {
            SubOffice Item1 = new SubOffice();
            Reporte01 rp = new Reporte01();
            SubOfficeLogica le = new SubOfficeLogica();
            if (Item == null)
                Item = new ReportVmBusiness();
            var listaAgent = await rp.graph_Year(Item);
            var listasubOffice = await le.Retrieve(Item1);
            return new ListaReportBusiness(Item, listaAgent, listasubOffice);
        }

    }
}