using System.Web.Mvc;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers.Seguridad
{
    public class ConfiguracionController : BaseController
    {
        public ActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IniciarSesion()
        {
            return Json("{}");
        }

        [HttpGet]
        public ActionResult TipoPublicacion()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerTipoPublicacion()
        {
            return Json("{}");
        }

        [HttpPost]
        public JsonResult GuardarTipoPublicacion()
        {
            return null;
        }
    }
}