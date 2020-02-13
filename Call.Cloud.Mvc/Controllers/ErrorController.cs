using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Call.Cloud.Mvc.Models.LoginVm;
using Call.Cloud.Mvc.Models.Acount;
using System.Threading.Tasks;
using Call.Cloud.Mvc.App_Start.Extenciones;
using Call.Cloud.Mvc.Models.DashBoard;
using Call.Cloud.Mvc.Controllers.Shared;


namespace Call.Cloud.Mvc.Controllers
{
    public class ErrorController:Controller
    {
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Login_User");
        }
    }
}