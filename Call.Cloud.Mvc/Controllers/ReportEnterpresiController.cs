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
    public class ReportEnterpresiController : Controller
    {
        // GET: ReportEnterpresi
        public async Task<ActionResult> ReportEnterpresi()
        {
            return View( await CrearModelo());
        }
         public async Task<JsonResult>chart_Enterpresi011_year(ReportVmEnterpresi filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.ejemplo(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_Enterpresi_whitelist_month(ReportVmEnterpresi filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.chart_google02(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> chart_Enterpresi_whitelist_Day(ReportVmEnterpresi filtro)
        {
            Reporte01 rp = new Reporte01();
            var datachart = await rp.Grafica_03(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Buscar(ReportVmEnterpresi filtro)
        {
            return View("Grid", await CrearModelo(filtro));
        }
        private async Task<LitaReportEnterpresi> CrearModelo(ReportVmEnterpresi Item = null)
        {
            Enterprise Item1 = new Enterprise();
            Reporte01 rp = new Reporte01();
            EnterpriseLogica le = new EnterpriseLogica();
            if (Item == null)
                Item = new ReportVmEnterpresi();
            var listaAgent = await rp.chart_google02(Item);
            var listaEnterprise = await le.Retrieve(Item1);
            return new LitaReportEnterpresi(Item, listaAgent, listaEnterprise);
        }

       

    }
}