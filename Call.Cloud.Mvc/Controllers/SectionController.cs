using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.Models.SectionVM;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Controllers
{
    public class SectionController : Controller
    {
        #region Mantenimiento
        //public async Task<ActionResult> Index(string respuesta = "", int id = 0)
        //{
        //    ViewBag.Mensaje = respuesta;
        //    return View(await CrearModelo(new Section()
        //    {
        //        PkSpeech = id
        //    }));
        //}
        //private async Task<ListaSectionVm> CrearModelo(Section Item = null)
        //{
        //    SpeechLogica oSpeechLogica = new SpeechLogica();
        //    SectionLogica oSectionLogica = new SectionLogica();
        //    if (Item == null)
        //        Item = new Section();
        //    var listaSection = await oSectionLogica.Retrieve(Item);
        //    var listaSpeech = await oSpeechLogica.Retrieve(new Speech());

        //    return new ListaSectionVm(Item, listaSection, listaSpeech);
        //}

        
        //public async Task<ActionResult> Buscar(Section filtro)
        //{
        //    return View("Grid", await CrearModelo(filtro));
        //}
        //[HttpGet]
        //public async Task<ActionResult> Editar(int id)
        //{
        //    SectionLogica oSectionLogica = new SectionLogica();
        //    SpeechLogica oSpeechLogica = new SpeechLogica();
        //    var item = (id == -1) ? new Section() : await oSectionLogica.Find(new Section
        //    {
        //        PkSection = id
        //    });
        //    var listaSpeech = await oSpeechLogica.Retrieve(new Speech());
        //    return View(new EditarSectionVm(item, listaSpeech));
        //}

        //[HttpPost]
        //public async Task<ActionResult> Editar(Section Item)
        //{
        //    string mensajeRespuesta = "";
        //    SectionLogica oRuleLogica = new SectionLogica();
        //    var rpta = await oRuleLogica.Edit(Item);
        //    if (rpta == 2)
        //        mensajeRespuesta = "Se modificó correctamente el registro";
        //    else if (rpta == 1)
        //        mensajeRespuesta = "Se agregó correctamente el registro";
        //    else
        //        mensajeRespuesta = "Ocurrió un error";

        //    return RedirectToAction("Index", "Section");
        //}

        ////*******************Agregar una Section dentro de un Speech********************
        //[HttpGet]
        //public async Task<ActionResult> EditarBySpeech(int id, string namespeech, int speech)
        //{
        //    Session["PkSpeech"] = speech;
        //    Session["PkSection"] = id;
        //    Session["SpeechName"] = namespeech;

        //    SectionLogica oSectionLogica = new SectionLogica();
        //    SpeechLogica oSpeechLogica = new SpeechLogica();

        //    var listaSpeech = await oSpeechLogica.Retrieve(new Speech());

        //    var item = (id == -1) ? new Section
        //    {
        //        PkSpeech = speech
        //    } : await oSectionLogica.Find(new Section
        //    {
        //        PkSection = id,
        //        PkSpeech = speech
        //    });

        //    return View(new EditarSectionVm(item, listaSpeech));
        //}


        //[HttpPost]
        //public async Task<ActionResult> EditarBySpeech(Section Item)
        //{
        //    int speech = (int)Session["PkSpeech"];
        //    string namespeech = (string)Session["SpeechName"];
        //    int sec = (int)Session["PkSection"];

        //    bool estado = Item.Status;
        //    Session["Estado"] = estado;

        //    string mensajeRespuesta = "";
        //    SectionLogica oRuleLogica = new SectionLogica();
        //    var rpta = await oRuleLogica.Edit(Item);
        //    if (rpta == 2)
        //        mensajeRespuesta = "Se modificó correctamente el registro";
        //    else if (rpta == 1)
        //        mensajeRespuesta = "Se agregó correctamente el registro";
        //    else
        //        mensajeRespuesta = "Ocurrió un error";

        //    return RedirectToAction("SectionBySpeech/" + speech, "Speech", new {section=sec, name=namespeech });
        //}

        ////******************************************************************************

        //public async Task<ActionResult> Eliminar(int id)
        //{

        //    string mensajeRespuesta = "";
        //    SectionLogica oRuleLogica = new SectionLogica();
        //    var rpta = await oRuleLogica.Delete(new Section
        //    {
        //        PkSection = id
        //    });

        //    if (rpta > 0)
        //        mensajeRespuesta = "Se eliminó correctamente el registro";
        //    else
        //        mensajeRespuesta = "Ocurrió un error";

        //    return RedirectToAction("Index", "Section");

        //}
        #endregion
        //public async Task<ActionResult> EliminarSection(int id, int speech)
        //{

        //    string mensajeRespuesta = "";
        //    SectionLogica oSectionLogica = new SectionLogica();

        //    ViewBag.pkSpeech = speech;

        //    var rpta = await oSectionLogica.Delete(new Section
        //    {
        //        PkSection = id
        //    });

        //    if (rpta > 0)
        //        mensajeRespuesta = "Se eliminó correctamente el registro";
        //    else
        //        mensajeRespuesta = "Ocurrió un error";

        //    return RedirectToAction("SectionBySpeech/" + speech, "Speech", new { pkSpeech=speech });

        //}

        
        //public async Task<ActionResult> WordRuleBySection(int id, string name, int speech, string namespeech)
        //{

        //    return PartialView("WordRuleBySection", await creacion(id,name,speech, namespeech)); //vista parcial 
        //                                                                                  //que me trae las "Reglas" y "Palabras Reglas"
        //}

        //public async Task<ListaWordRuleSectionVm> creacion(int id, string name, int speech, string namespeech="")
        //    //captura el pkSection, sectionName, pkSpeech, speechName dando click al botón "Listar"
        //{
        //    SectionLogica section = new SectionLogica();
        //    WordRuleLogica logica = new WordRuleLogica();

        //    Session["SectionName"] = name;
        //    Session["PkSection"] = id;
        //    Session["pkSpeech"] = speech;
        //    Session["SpeechName"] = namespeech;
            
        //    var filtro = await logica.Find(new WordRule());
        //    var reglas = await section.RetrieveSectionRuleWordRule(id);//trae las reglas --> vista: WordRuleBySection que está dentro de la vista "SectionBySpeech"
        //    var WordRuleLista = await logica.ListarWordRule(id);//trae las palabras reglas --> vista: GridWordRule que está dentro de la vista "WordRuleBySection"
         
        //    return new ListaWordRuleSectionVm(filtro, WordRuleLista, reglas);
        //}
        
        
    }
}