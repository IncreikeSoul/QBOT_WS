using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatsonQBotRealTime.Controllers
{
    public class WatsonController : Controller
    {
        // GET: Watson
        public ActionResult AudioTranscription()
        {
            return View();
        }
    }
}