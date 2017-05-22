using System.Web.Mvc;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class GestionController : BaseController
    {

        public GestionController()
        {

        }

        public ActionResult Inicio() => View();
        public ActionResult Noticia() => View();
        public ActionResult Actualidad() => View();
        public ActionResult Evento() => View();
        public ActionResult Comunicado() => View();
    }
}