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
    //public class Login_userController : Controller
    public class Login_userController : ApplicationController<LogOnModel>
    {
        // GET: Login_user
        public ActionResult Login_user()
        {
            return View();
        }

        public ActionResult Principal()
        {
            LogOnModel sessionModel = GetLogOnSessionModel();
            if (sessionModel is null)
            {
                return RedirectToAction("Login_User");
            }
            else
            {
                //Alertas alerta = new Alertas();
                //var NumAlertas = alerta.NumeroAlertas();
                //ViewBag.Message = NumAlertas;
                //var NumNotificaciones = alerta.NumeroNotificaciones();
                //ViewBag.NumNotificaciones = NumNotificaciones;
                return View();
            }
        }
   
        public JsonResult ListarAlertaJson()
        {
            Alertas alerta = new Alertas();
            List<Models.Alertas.AlertaModel> ls = new List<Models.Alertas.AlertaModel>();
            ls = alerta.ListaAlertas();
            return Json(ls, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarNotificacionJson()
        {
            Alertas alerta = new Alertas();
            List<Models.Alertas.AlertaModel> ls = new List<Models.Alertas.AlertaModel>();
            ls = alerta.ListaNotificaciones();
            return Json(ls, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Mantenimiento()
        {
            return View();
        }


        public JsonResult Login_usuario001(LogOnModel filtro){

            ///if (ModelState.IsValid)
            //{
                /*Set model to session*/
                SetLogOnSessionModel(filtro);
                /*Shows the session*/
                LogOnModel sessionModel = GetLogOnSessionModel();
                //return RedirectToAction("Index", "Home");
            //}

            LOGIN lg = new LOGIN();
            var datos = lg.Login_usuario(filtro);
          
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> grafica1(Elements filtro)
        {
            Dashboard lg = new Dashboard();
            var datos = await lg.grafica1(filtro);
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Office_Year(Elements filtro)
        {
            Dashboard lg = new Dashboard();
            var datos = await lg.grafica2(filtro);
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> graficaCall(Elements filtro)
        {
            Dashboard lg = new Dashboard();
            var datos = await lg.grafica3(filtro);
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> graficaBusiness(Elements filtro)
        {
            Dashboard lg = new Dashboard();
            var datos = await lg.grafica4(filtro);
            return Json(datos, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LogOff()
        {
            /*distroy current session and go to login page*/
            AbandonSession();
            return RedirectToAction("Login_user", "Login_user");
        }
    }
}