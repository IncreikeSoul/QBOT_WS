using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Mvc.Models.ReportsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Call.Cloud.Logica;
using Call.Cloud.Modelo;

namespace Call.Cloud.Mvc.Controllers
{
    public class ReportsController : Controller
    {
         // GET: Reports
        public async Task<ActionResult> Index()
        {
          
            return View(await CrearModelo());
        }
      
        public async Task<JsonResult> datos(ReportsVm filtro) {

            Reporte rp = new Reporte();
            var datachart = await rp.ejemplo(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

      public async Task<JsonResult> chart_google1(ReportsVm filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.chart_google02(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

       public async Task<JsonResult> chart_google03(ReportsVm filtro)
        {
            Reporte rp = new Reporte();
            var datachart = await rp.Grafica_03(filtro);
            return Json(datachart, JsonRequestBehavior.AllowGet);
        }

       
       public async Task<ActionResult> Buscar(ReportsVm filtro)
       {
           //ReportsVm filtro = new ReportsVm();

           return View("Grid", await CrearModelo(filtro));
       }

       private async Task<ListarReports> CrearModelo(ReportsVm Item = null)
       {
           Enterprise Item1 = new Enterprise();
           Reporte rp = new Reporte();
           EnterpriseLogica le = new EnterpriseLogica();
           if (Item == null)
               Item = new ReportsVm();
           var listaAgent = await rp.ejemplo_pueva(Item);
           var listaEnterprise = await le.Retrieve(Item1);
           return new ListarReports(Item, listaAgent,listaEnterprise);
       }
     
    }
    


    }
