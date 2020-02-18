using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Controllers
{
    public class CargaAudioController : Controller
    {
        // GET: CargaAudio
        public ActionResult CargaAudio()
        {
            return View();
        }

        // POST: CargaAudio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
