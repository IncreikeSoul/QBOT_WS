using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Mvc.Models.ReportVM01;
using Call.Cloud.Modelo;
using Call.Cloud.Logica;

namespace Call.Cloud.Mvc.Controllers
{
    public class ReportSubOfficeWhiteListController : Controller
    {
        // GET: ReportSubOfficeWhiteList
        public async  Task<ActionResult> ReportSubOfficeWhiteList()
        {
            return View(await CrearModelo ());
        }

        public async Task<JsonResult> chart_whiteSubOffice_Yaer(ReportVmSubOffice filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.grafica0001(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_whiteSubOffice_month(ReportVmSubOffice filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.grafica0002(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult>chart_whiteSubOffice_Day(ReportVmSubOffice filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.grafica0003(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_WhiteListSuboffice_Year_Organizational(ReportVmSubOffice filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.grafica0001_Organizational(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }


        private async Task<ListaReportSubOffice> CrearModelo(ReportVmSubOffice Item = null)
        {
            Office Item1 = new Office();
            Reporte01 rp = new Reporte01();
            OfficeLogica le = new OfficeLogica();
            if (Item == null)
                Item = new ReportVmSubOffice();
            var listaAgent = await rp.grafica0001(Item);
            var listaEnterprise = await le.Retrieve(Item1);
            return new ListaReportSubOffice(Item, listaAgent, listaEnterprise);
        }

    }
}