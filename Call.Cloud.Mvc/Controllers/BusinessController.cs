using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Controllers
{
    public class BusinessController : Controller
    {
        public async Task<JsonResult> ListarNegocios(Business objBusinessBE)
        {
            BusinessLogica oBusinessLogica = new BusinessLogica();
            var lstBusinessBE = await oBusinessLogica.NegocioListar(objBusinessBE);// (objBusinessBE);
            return Json(lstBusinessBE, JsonRequestBehavior.AllowGet);
        }
    }
}