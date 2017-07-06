using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Presentacion.Web.Acceso.Configuracion;

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

        [HttpGet]
        public ActionResult Objeto()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerObjeto()
        {
            return Json(Ejecutar(() =>
            {
                return new ObjetoProxy(ruta, usuario).Obtener();
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarObjeto(ObjetoDto objeto)
        {
            return Json(Ejecutar(() =>
            {
                return new ObjetoProxy(ruta, usuario).Guardar(objeto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Rol()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerRol()
        {
            return Json(Ejecutar(() =>
            {
                return new RolProxy(ruta, usuario).Obtener();
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarRol(RolDto rol)
        {
            return Json(Ejecutar(() =>
            {
                return new RolProxy(ruta, usuario).Guardar(rol);
            }), JsonRequestBehavior.AllowGet);
        }
    }
}