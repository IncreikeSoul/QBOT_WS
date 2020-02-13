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
using Call.Cloud.Mvc.Models.OfficeVM;

namespace Call.Cloud.Mvc.Controllers
{
    public class ReportSubOfficeController : Controller
    {
        // GET: ReportSubOffice
        public async  Task<ActionResult> SubOffice()
        {
            return View( await CrearModelo ());
        }


        public async Task<JsonResult> chart_SubOffice_Year(ReportVmSubOffice filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.grafica0001(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult>chart_SubOffice_Month(ReportVmSubOffice filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.grafica0002(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult>chart_SubOffice_Day(ReportVmSubOffice filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.grafica0003(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_SubOffice_Year_Organizational(ReportVmSubOffice filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.grafica0001_Organizational(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }


        private async Task<ListaReportSubOffice> CrearModelo(ReportVmSubOffice Item = null)
        {
            Office Item1 = new Office();
            Reporte rp = new Reporte();
            OfficeLogica le = new OfficeLogica();
            if (Item == null)
                Item = new ReportVmSubOffice();
            var listaAgent = await rp.grafica0001(Item);
            var listaEnterprise = await le.Retrieve(Item1);
            return new ListaReportSubOffice(Item, listaAgent, listaEnterprise);
        }



    }
}