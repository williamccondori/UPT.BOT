using System.Web.Mvc;
using UPT.BOT.Presentacion.Web.Acceso.Analisis;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class AnalisisController : BaseController
    {
        ClienteProxy proxyCliente;

        public AnalisisController()
        {
            proxyCliente = new ClienteProxy(gsRuta, gsVersion, gsServicio);
        }

        public ActionResult Inicio()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerCliente()
        {
            //return Json(Ejecutar(() =>
            //{
            //    return proxyCliente.Obtener();
            //}), JsonRequestBehavior.AllowGet);}
            return null;
        }

        [HttpGet]
        public JsonResult ObtenerMensajeXCliente()
        {
            //return Json(Ejecutar(() =>
            //{
            //    return proxyCliente.ObtenerMensajeXCanal();
            //}), JsonRequestBehavior.AllowGet);
            return null;
        }
    }
}