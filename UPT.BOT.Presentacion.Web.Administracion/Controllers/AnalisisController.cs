using System.Web.Mvc;
using UPT.BOT.Presentacion.Web.Acceso.Analisis;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class AnalisisController : BaseController
    {
        public AnalisisController()
        {

        }

        public ActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerCliente()
        {
            ClienteProxy proxyCliente = new ClienteProxy(ruta, usuario);
            return Json(Ejecutar(() => proxyCliente.Obtener())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerMensajeXCliente()
        {
            ClienteProxy proxyCliente = new ClienteProxy(ruta, usuario);
            return Json(Ejecutar(() => proxyCliente.ObtenerMensajesNumero())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerResumenMes()
        {
            MensajeProxy proxyMensaje = new MensajeProxy(ruta, usuario);
            return Json(Ejecutar(() => proxyMensaje.ObtenerResumenMes())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerResumenIntenciones()
        {
            MensajeProxy proxyMensaje = new MensajeProxy(ruta, usuario);
            return Json(Ejecutar(() => proxyMensaje.ObtenerResumenIntenciones())
            , JsonRequestBehavior.AllowGet);
        }
    }
}