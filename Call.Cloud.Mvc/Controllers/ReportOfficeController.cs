using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Mvc.Models.ReportVM01;
using System.Threading.Tasks;
using Call.Cloud.Logica;
using Call.Cloud.Modelo;

namespace Call.Cloud.Mvc.Controllers
{
    public class ReportOfficeController : Controller
    {
        // GET: ReportOffice
        public async Task<ActionResult> ReportOffice()
        {
            return View(await CrearModelo());
        }
        public async Task<JsonResult> chart_whiteListOffice_Year(ReporVmOffice filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.grafica01(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult>chart_whiteListOffice_Month(ReporVmOffice filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.graficas002(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> char_whiteListOffice_Day(ReporVmOffice filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.grafica003(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult>chart_whileListOffice_Year_Organitional(ReporVmOffice filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.grafica_office_Year_organi(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

        private async Task<ListaReportOffice> CrearModelo(ReporVmOffice Item = null)
        {
            Enterprise Item1 = new Enterprise();
            
            Reporte01 rl = new Reporte01();
            EnterpriseLogica le = new EnterpriseLogica();
            if (Item == null)
                Item = new ReporVmOffice();
            var listaEnterprise = await le.Retrieve(Item1);
            var datos_enterprise = await rl.grafica01(Item);
            return new ListaReportOffice(Item, datos_enterprise, listaEnterprise);
        }

    }
}