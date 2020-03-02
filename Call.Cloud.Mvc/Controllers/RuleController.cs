using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.Models.RuleVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Controllers
{
    public class RuleController : Controller
    {
        //public async Task<ActionResult> Index(string respuesta = "",int id=0)
        //{
        //    ViewBag.Mensaje = respuesta;
        //    return View(await CrearModelo(new Rule()
        //    {
        //        PkSection=id
        //    }));
        //}
        //private async Task<ListaRuleVm> CrearModelo(Rule Item = null)
        //{

        //    RuleLogica oRuleLogica = new RuleLogica();
        //    SectionLogica oSectionLogica = new SectionLogica();
        //    if (Item == null)
        //        Item = new Rule();
        //    var listaAgent = await oRuleLogica.Retrieve(Item);
        //    var listaSecciones = await oSectionLogica.RetrieveDrop(new Section
        //    {
        //        SectionName=""
        //    });
        //    return new ListaRuleVm(Item, listaAgent, listaSecciones);
        //}
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Buscar(Rule filtro)
        //{
        //    return View("Grid", await CrearModelo(filtro));
        //}

        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            RuleLogica oRuleLogica = new RuleLogica();
            SectionLogica oSectionLogica = new SectionLogica();
            
            var listaSecciones = await oSectionLogica.Retrieve(new Section());
            var item = (id==-1)?new Rule(): await oRuleLogica.Find(new Rule
            {
                PkRule = id
            });
            return View(new EditarRuleVm(item, listaSecciones));
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Rule Item)
        {
#pragma warning disable CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            string mensajeRespuesta = "";
#pragma warning restore CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            RuleLogica oRuleLogica = new RuleLogica();
            var rpta = await oRuleLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "Rule");

        }

        //--------USADO PARA LA VISTA RULEBYSECTION --------------------
        [HttpGet]
        public async Task<ActionResult> EditarRuleBySection(int id, int section, int speech, string namespeech, string namesection)
        {
            RuleLogica oRuleLogica = new RuleLogica();
            SectionLogica oSectionLogica = new SectionLogica();

            Session["PkRule"] = id;
            Session["PkSpeech"] = speech;
            Session["PkSection"] = section;
            Session["SpeechName"] = namespeech;
            Session["SectionName"] = namesection;


            var listaSecciones = await oSectionLogica.Retrieve(new Section());

            var item = (id == -1) ? new Rule
            {
                PkSection=section
            } : await oRuleLogica.Find(new Rule
            {
                PkRule = id,
                PkSection = section
            });

            return View(new EditarRuleBySectionVM(item,listaSecciones));
        }

        [HttpPost]
        public async Task<ActionResult> EditarRuleBySection(Rule Item)
        {
            
            int pk = (int)Session["PkRule"];
            int speech = (int)Session["PkSpeech"];
            int sec = (int)Session["PkSection"];
            string namespeech = (string)Session["SpeechName"];
            string namesection = (string)Session["SectionName"];

            bool estado = Item.Status;
            Session["Estado"] = estado;
            
#pragma warning disable CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            string mensajeRespuesta = "";
#pragma warning restore CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            RuleLogica oRuleLogica = new RuleLogica();
            var rpta = await oRuleLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("SectionBySpeech/" + speech, "Speech", new { sec, estado, namespeech, PkSection = sec, sectionname = namesection, name = namespeech });

        }        

        public async Task<ActionResult> Eliminar(int id)
        {
#pragma warning disable CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            string mensajeRespuesta = "";
#pragma warning restore CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            RuleLogica oRuleLogica = new RuleLogica();
            var rpta = await oRuleLogica.Delete(new Rule
            {
                PkRule = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "Rule");

        }
        public async Task<JsonResult> EliminarRuleGrid(int id)
        {
            string mensajeRespuesta = "";
            RuleLogica oRuleLogica = new RuleLogica();
            var rpta = await oRuleLogica.Delete(new Rule
            {
                PkRule = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";
            return Json(mensajeRespuesta, JsonRequestBehavior.AllowGet);           

        }

        public async Task<ActionResult> EliminarRule(int id, int sec, int speech, string namespeech, string namesection)
        {            
#pragma warning disable CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            string mensajeRespuesta = "";
#pragma warning restore CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            RuleLogica oRuleLogica = new RuleLogica();
            
            Rule item = new Rule();
            bool estado = item.Status;
            Session["Estado"] = estado;

            var rpta = await oRuleLogica.Delete(new Rule
            {
                PkRule = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";
            return RedirectToAction("SectionBySpeech/" + speech, "Speech", new { sec, estado, namespeech, PkSection = sec, name = namespeech, sectionname =namesection});


        }


    }
}