using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Presentacion.Web.Acceso.Configuracion;
using UPT.BOT.Presentacion.Web.Administracion.Seguridad;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class ConfiguracionController : BaseController
    {
        RolProxy goRolProxy;
        UsuarioProxy goUsuarioProxy;

        public ConfiguracionController()
        {
            goRolProxy = new RolProxy(gsRuta, gsVersion, gsServicio);
            goUsuarioProxy = new UsuarioProxy(gsRuta, gsVersion, gsServicio);
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Acceso()
        {
            return View();
        }

        public ActionResult Usuario()
        {
            return View();
        }

        public ActionResult Objeto()
        {
            return View();
        }

        public ActionResult Rol()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerRol()
        {
            return Json(Ejecutar(() =>
            {
                return goRolProxy.Obtener();
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarRol(RolRegistroDto aoRol)
        {
            return Json(Ejecutar(() =>
            {
                aoRol.Usuario = Sesion.Usuario();
                return goRolProxy.Guardar(aoRol);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerUsuario()
        {
            return Json(Ejecutar(() =>
            {
                return goUsuarioProxy.Obtener();
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(UsuarioRegistroDto aoUsuario)
        {
            return Json(Ejecutar(() =>
            {
                aoUsuario.Usuario = Sesion.Usuario();
                return goUsuarioProxy.Guardar(aoUsuario);
            }), JsonRequestBehavior.AllowGet);
        }
    }
}