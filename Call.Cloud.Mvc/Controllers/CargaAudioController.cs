using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
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

        // POST: CargaAudio/IniciarCarga
        [HttpPost]
        public ActionResult IniciarCarga(HttpContext context)
        {
            ProcessRequest(context);
            return View();
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string dirFullPath = HostingEnvironment.MapPath("~/Archivos/");
            string[] files;
            int numFiles;
            files = System.IO.Directory.GetFiles(dirFullPath);
            numFiles = files.Length;
            numFiles += 1;

            string str_image = "";

            foreach (string s in context.Request.Files)
            {
                HttpPostedFile file = context.Request.Files[s];
                //  int fileSizeInBytes = file.ContentLength;
                string fileName = file.FileName;
                string fileExtension = file.ContentType;

                if (!string.IsNullOrEmpty(fileName))
                {
                    fileExtension = Path.GetExtension(fileName);
                    str_image = "MyPHOTO_" + numFiles.ToString() + fileExtension;
                    string pathToSave_100 = HostingEnvironment.MapPath("~/Archivos/") + str_image;
                    file.SaveAs(pathToSave_100);
                }
            }
            context.Response.Write(str_image);
        }

    }
}
