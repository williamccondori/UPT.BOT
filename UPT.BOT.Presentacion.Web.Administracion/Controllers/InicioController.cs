using System.Web.Mvc;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers.Aplicacion
{
    public class InicioController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Portada()
        {
            return View();
        }
    }
}