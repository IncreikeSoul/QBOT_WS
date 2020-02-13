using System.Web.Mvc;
using Call.Cloud.Logica;
using Call.Cloud.Modelo;
using System.Threading.Tasks;
using Call.Cloud.Mvc.Models.WhiteListVM;

namespace Call.Cloud.Mvc.Controllers
{
    public class WhiteListController : Controller
    {
        
        public async Task<ActionResult> Index(string respuesta="")
        {
            ViewBag.Mensaje = respuesta;
            return View(await CrearModelo());

        }

        private async Task<ListaWhiteListVM> CrearModelo(WhiteList Item = null)
        {
            WhiteListLogica whitelogica = new WhiteListLogica();

            EnterpriseLogica enterlogica = new EnterpriseLogica();
            if (Item == null)
                Item = new WhiteList();
            var listaWhite = await whitelogica.Retrieve(Item);
            var listaEnterprise = await enterlogica.Retrieve(null);
            
            return new ListaWhiteListVM(Item,listaWhite, listaEnterprise);
        }


        private async Task<ListaWhiteListVM> Busqueda2(WhiteList Item = null)
        {
            WhiteListLogica whitelogica = new WhiteListLogica();
            EnterpriseLogica enterlogica = new EnterpriseLogica();
            if (Item == null)
                Item = new WhiteList();
            var busqueda = await whitelogica.Buscar(Item);
            var listaEnterprise = await enterlogica.Retrieve(null);
            return new ListaWhiteListVM(Item,busqueda,listaEnterprise);
        }
        
        
        public async Task<ActionResult> Buscar(WhiteList filtro)
        {
            return View("Grid", await Busqueda2(filtro));
        }

        //private async Task<ListaWhiteListVM> BusquedaYhimy(WhiteList Item)
        //{
        //    WhiteListLogica whitelogica = new WhiteListLogica();
        //    EnterpriseLogica enterlogica = new EnterpriseLogica();
        //    var listaEnterprise =  await enterlogica.Retrieve(null);

        //    var busqueda =  whitelogica.BuscarYhimy(Item);

        //    return new ListaWhiteListVM(Item, busqueda, listaEnterprise);// "Index", "WhiteList");
        //}

        public string Buscqueda(int id)
        {
           
            string mensaje = "";
            WhiteListLogica whitelogica = new WhiteListLogica();
            var rpta =  whitelogica.BuscarYhimy(id);

            mensaje = "Proceso ejecutado correctamente";//:"Ocurrió un error";

            return mensaje;
        }

        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            WhiteListLogica whitelogica = new WhiteListLogica();
            EnterpriseLogica enterlogica = new EnterpriseLogica();
            var item = (id == -1) ? new WhiteList() : await whitelogica.Find(new WhiteList
            {
                pk_word = id
            });

            var listaEnterprise = await enterlogica.Retrieve(null);
            return View(new EditarWhiteList(item,listaEnterprise));
        }

        [HttpPost]
        public async Task<ActionResult> Editar(WhiteList item)
        {
            string mensaje = "";
            WhiteListLogica whitelogica = new WhiteListLogica();

            var rpta = await whitelogica.Edit(item);
            if (rpta == 2)
                mensaje = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensaje = "Se agregó correctamente el registro";
            else
                mensaje = "Ocurrió un error";
            return RedirectToAction("Index", "WhiteList", new { respuesta = mensaje });
        }

        public async Task<ActionResult> Eliminar(int id)
        {
            string mensaje = "";
            WhiteListLogica whitelogica = new WhiteListLogica();
            var rpta = await whitelogica.Delete(new WhiteList
                {
                pk_word = id
                });

            if (rpta > 0)
                mensaje = "Se eliminó correctamente el registro";
            else
                mensaje = "Ocurrió un error";
            return RedirectToAction("Index", "WhiteList", new { respuesta = mensaje });
        } 
        

    }
}