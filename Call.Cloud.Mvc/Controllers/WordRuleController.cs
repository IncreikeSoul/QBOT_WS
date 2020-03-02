using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.Models.WordRuleVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Controllers
{
    public class WordRuleController : Controller
    {
        public async Task<ActionResult> Index(string respuesta = "",int id=0)
        {
            ViewBag.Mensaje = respuesta;
            return View(await CrearModelo(new WordRule()
            {
                 PkRule=id
            }));
        }
        private async Task<ListaWordRuleVm> CrearModelo(WordRule Item = null)
        {

            WordRuleLogica oRuleLogica = new WordRuleLogica();
            if (Item == null)
                Item = new WordRule();
            var listaAgent = await oRuleLogica.Retrieve(Item);
            return new ListaWordRuleVm(Item, listaAgent);
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Buscar(WordRule filtro)
        {
            return View("Grid", await CrearModelo(filtro));
        }
        [HttpGet]
        public async Task<ActionResult> Editar(int id, int rule)
        {
            WordRuleLogica oWordRuleLogica = new WordRuleLogica();
            RuleLogica oRuleLogica = new RuleLogica();

            var listaReglas = await oRuleLogica.Retrieve(new Rule());

            var item = (id == -1) ? new WordRule
            {
                PkRule = rule
            } : await oWordRuleLogica.Find(new WordRule
               {
                PkWorldRule = id,
                PkRule = rule
            });
            return View(new EditarWordRuleVm(item, listaReglas));
        }
        [HttpPost]
        public async Task<ActionResult> Editar(WordRule Item)
        {
#pragma warning disable CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            string mensajeRespuesta = "";
#pragma warning restore CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            WordRuleLogica oRuleLogica = new WordRuleLogica();
            var rpta = await oRuleLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "WordRule");
        }
        //*********** Editar una WordRule por Regla, dentro de la vista WordRuleBySection***************

        [HttpGet]
        public async Task<ActionResult> EditarByRegla(int id, int rules, int speech, int section, string namespeech, string namesection)
        {
            WordRuleLogica oWordRuleLogica = new WordRuleLogica();
            RuleLogica oRuleLogica = new RuleLogica();

            Session["PkRule"] = rules;
            Session["pkSpeech"] = speech;
            Session["PkSection"] = section;
            Session["SpeechName"] = namespeech;
            Session["SectionName"] = namesection;

            var listaReglas = await oRuleLogica.Retrieve(new Rule());
            
            var item = (id == -1) ? new WordRule
            {
                PkRule = rules
            } : await oWordRuleLogica.Find(new WordRule
            {
                PkWorldRule = id,
                PkRule = rules
            });
            return View(new EditarWordRuleVm(item, listaReglas));
        }
        [HttpPost]
        public async Task<ActionResult> EditarByRegla(WordRule Item)
        {
            int pk = (int)Session["PkRule"];
            int speech = 0;
            speech = (int)Session["pkSpeech"];
            int sec = 0;
            sec = (int)Session["PkSection"];

            string namespeech = (string)Session["SpeechName"];
            string namesection = (string)Session["SectionName"];

            bool estado = Item.Status;
            Session["Estado"] = estado;
            
#pragma warning disable CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            string mensajeRespuesta = "";
#pragma warning restore CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            WordRuleLogica oRuleLogica = new WordRuleLogica();
            var rpta = await oRuleLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            
            return RedirectToAction("SectionBySpeech/" + speech, "Speech", new { sec, estado, namespeech,PkSection = sec, sectionname = namesection, name = namespeech});
            
            
        }

        //**********************************************************************************************
        public async Task<ActionResult> Eliminar(int id)
        {
#pragma warning disable CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            string mensajeRespuesta = "";
#pragma warning restore CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            WordRuleLogica oRuleLogica = new WordRuleLogica();
            var rpta = await oRuleLogica.Delete(new WordRule
            {
                PkWorldRule = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";
            return RedirectToAction("Index", "WordRule");

        }


        public async Task<ActionResult> EliminarWordRule(int id, int sec, int speech, string namespeech, string namesection)
        {

#pragma warning disable CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            string mensajeRespuesta = "";
#pragma warning restore CS0219 // The variable 'mensajeRespuesta' is assigned but its value is never used
            WordRuleLogica oRuleLogica = new WordRuleLogica();

            WordRule item = new WordRule();
            bool estado = item.Status;
            Session["Estado"] = estado;

            var rpta = await oRuleLogica.Delete(new WordRule
            {
                PkWorldRule = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";
            return RedirectToAction("SectionBySpeech/"+speech, "Speech", new { sec, estado, namespeech, PkSection = sec,name = namespeech, sectionname =namesection});

        }
        
    }
}