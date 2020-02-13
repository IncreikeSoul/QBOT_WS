using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.App_Start.Extenciones;

namespace Call.Cloud.Mvc.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Bienvenido()
        {
            return View();
        }
    }
}