using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Presentacion.Web.Administracion.Collections;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class GestionController : BaseController
    {
        GestionCollection coleccion;

        public GestionController()
        {
            coleccion = new GestionCollection(ruta);
        }

        // página de inicio

        [HttpGet]
        public ActionResult Inicio() => View();

        // acreditacion

        [HttpGet]
        public ActionResult Acreditacion() => View();

        [HttpGet]
        public JsonResult ObtenerAcreditacion() => Json(Ejecutar(() => coleccion.proxyAcreditacion.Obtener()), JsonRequestBehavior.AllowGet);

        [HttpPost]
        public JsonResult GuardarAcreditacion(AcreditacionDto entidad) => Json(Ejecutar(() => coleccion.proxyAcreditacion.Guardar(entidad)), JsonRequestBehavior.AllowGet);

        [HttpPost]
        public JsonResult EliminarAcreditacion(AcreditacionDto entidad) => Json(Ejecutar(() => coleccion.proxyAcreditacion.Eliminar(entidad.CodigoAdjunto)), JsonRequestBehavior.AllowGet);

        // noticia

        [HttpGet]
        public ActionResult Noticia() => View();

        [HttpGet]
        public JsonResult ObtenerNoticia() => Json(Ejecutar(() => coleccion.proxyNoticia.Obtener()), JsonRequestBehavior.AllowGet);

        // actualidad

        [HttpGet]
        public ActionResult Actualidad() => View();

        [HttpGet]
        public JsonResult ObtenerActualidad() => Json(Ejecutar(() => coleccion.proxyActualidad.Obtener()), JsonRequestBehavior.AllowGet);

        // evento

        [HttpGet]
        public ActionResult Evento() => View();

        [HttpGet]
        public JsonResult ObtenerEvento() => Json(Ejecutar(() => coleccion.proxyEvento.Obtener()), JsonRequestBehavior.AllowGet);






        [HttpGet]
        public ActionResult Comunicado() => View();


        [HttpGet]
        public JsonResult ObtenerConvenio() => Json(Ejecutar(() => coleccion.proxyConvenio.Obtener()), JsonRequestBehavior.AllowGet);



    }
}