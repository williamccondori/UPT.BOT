using System.Web.Mvc;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class ConfiguracionController : BaseController
    {
        public ConfiguracionController()
        {

        }

        public ActionResult Inicio() => View();
        public ActionResult Acceso() => View();
        public ActionResult Usuario() => View();
        public ActionResult Objeto() => View();
        public ActionResult Rol() => View();

        //[HttpGet]
        //public JsonResult ObtenerRol() => Json(Ejecutar(() => goRolProxy.Obtener()), JsonRequestBehavior.AllowGet);
    }
}