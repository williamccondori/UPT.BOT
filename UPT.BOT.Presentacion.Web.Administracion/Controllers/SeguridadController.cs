using System.Web.Mvc;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class SeguridadController : Controller
    {
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Validar(DtoUsuarioSesion aoDtoUsuarioSesion)
        {
            return RedirectToAction("Inicio");
        }
    }

    public class DtoUsuarioSesion
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}