using System.Web.Mvc;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class EncuestaController : BaseController
    {
        public EncuestaController()
        {

        }

        public ActionResult Inicio()
        {
            return View();
        }
    }
}