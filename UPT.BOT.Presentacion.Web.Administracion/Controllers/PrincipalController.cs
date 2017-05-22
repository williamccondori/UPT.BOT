using System.Web.Mvc;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class PrincipalController : BaseController
    {
        public ActionResult Inicio() => View();
    }
}