using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;
using UPT.BOT.Presentacion.Web.Acceso.Gestion;
using UPT.BOT.Presentacion.Web.Administracion.Seguridad;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class GestionController : BaseController
    {
        NoticiaProxy goNoticiaProxy;

        public GestionController()
        {
            goNoticiaProxy = new NoticiaProxy(gsRuta, gsVersion, gsServicio);
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Noticia()
        {
            return View();
        }

        public ActionResult Actualidad()
        {
            return View();
        }

        public ActionResult Evento()
        {
            return View();
        }

        public ActionResult Comunicado()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerNoticia()
        {
            return Json(Ejecutar(() =>
            {
                return goNoticiaProxy.Obtener();
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarNoticia(NoticiaRegistroDto aoNoticia)
        {
            return Json(Ejecutar(() =>
            {
                aoNoticia.Usuario = Sesion.Usuario();
                return goNoticiaProxy.Guardar(aoNoticia);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult EliminarNoticia(NoticiaRegistroDto aoNoticia)
        {
            return Json(Ejecutar(() =>
            {
                aoNoticia.Usuario = Sesion.Usuario();
                return goNoticiaProxy.Eliminar(aoNoticia);
            }), JsonRequestBehavior.AllowGet);
        }
    }
}