using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.Models.ReportsVM;
using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Logica;
using Call.Cloud.Modelo;

namespace Call.Cloud.Mvc.Controllers
{
    public class ReportBusinessController : Controller
    {
        // GET: ReportBusiness
        public async  Task<ActionResult> ReportBusiness()
        {
            return View(await CrearModelo());
        }

        public async Task<JsonResult> chart_Business_Year(ReportVmBusiness filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.graph_Year(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult>chart_Busines_Month(ReportVmBusiness filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.graph_Month(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult>chart_Business_Day(ReportVmBusiness filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.graph_Day(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_Business_Year_Organizational(ReportVmBusiness filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.graph_Business_Year_Organizational(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        private async Task<ListaReportBusiness> CrearModelo(ReportVmBusiness Item = null)
        {
            SubOffice Item1 = new SubOffice();
            Reporte rp = new Reporte();
            SubOfficeLogica le = new SubOfficeLogica();
            if (Item == null)
                Item = new ReportVmBusiness();
            var listaAgent = await rp.graph_Year(Item);
            var listasubOffice = await le.Retrieve(Item1);
            return new ListaReportBusiness(Item, listaAgent, listasubOffice);
        }


    }
}