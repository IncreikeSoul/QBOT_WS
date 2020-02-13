using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//using SessionManageMVC.Models;

namespace Call.Cloud.Mvc.Controllers.Shared
{
    public class ApplicationController<TSource> : Controller
    {
        private const string LogOnSession = "LogOnSession";
        private const string ErrorController = "Error";
        private const string LogOnController = "Login_User";
        private const string LogOnAction = "Login_User";

        protected ApplicationController()
        {
            
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            /*important to check both, because logOnController should be access able with out any session*/
            if (!IsNonSessionController(requestContext) && !HasSession())
            {
                Rederect(requestContext, Url.Action(LogOnAction, LogOnController));
            }
        }

        private bool IsNonSessionController(RequestContext requestContext)
        {
            var currentController = requestContext.RouteData.Values["controller"].ToString().ToLower();
            var nonSessionedController = new List<string>() {ErrorController.ToLower(), LogOnController.ToLower()};
            return nonSessionedController.Contains(currentController);
        }

        private void Rederect(RequestContext requestContext, string action)
        {
            requestContext.HttpContext.Response.Clear();
            requestContext.HttpContext.Response.Redirect(action);
            requestContext.HttpContext.Response.End();
        }

        protected bool HasSession()
        {
            return Session[LogOnSession] != null;
        }

        protected TSource GetLogOnSessionModel()
        {
            return (TSource)this.Session[LogOnSession];
        }

        protected void SetLogOnSessionModel(TSource model)
        {
            Session[LogOnSession] = model;
        }

        protected void AbandonSession()
        {
            if (HasSession())
            {
                Session.Abandon();
            }
        }

    }
}
