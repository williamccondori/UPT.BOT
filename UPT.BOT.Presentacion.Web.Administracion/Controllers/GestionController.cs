using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Presentacion.Web.Administracion.Collections;
using UPT.BOT.Presentacion.Web.Administracion.Seguridad;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class GestionController : BaseController
    {
        private GestionCollection coleccion;

        public GestionController()
        {
            Ejecutar(() =>
            {
                coleccion = new GestionCollection(ruta);
            });
        }

        [HttpGet]
        public ActionResult Inicio()
        {
            return View();
        }

        // acreditacion

        [HttpGet]
        public ActionResult Acreditacion() => View();

        [HttpGet]
        public JsonResult ObtenerAcreditacion() => Json(Ejecutar(() => coleccion.proxyAcreditacion.Obtener()), JsonRequestBehavior.AllowGet);

        [HttpPost]
        public JsonResult GuardarAcreditacion(AcreditacionDto entidad) => Json(Ejecutar(() => coleccion.proxyAcreditacion.Guardar(entidad)), JsonRequestBehavior.AllowGet);

        [HttpPost]
        public JsonResult EliminarAcreditacion(AcreditacionDto entidad) => Json(Ejecutar(() => coleccion.proxyAcreditacion.Eliminar(entidad.CodigoAdjunto)), JsonRequestBehavior.AllowGet);


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


        public ActionResult Formato() => View();
        public ActionResult Reglamento() => View();
        public ActionResult Boletin() => View();

        [HttpGet]
        public ActionResult Comunicado()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerConvenio()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyConvenio.Obtener())
            , JsonRequestBehavior.AllowGet);
        }



        // gestion de documentos

        [HttpGet]
        public ActionResult Documento()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerFormato()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyFormato.Obtener())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarFormato(FormatoDto formato)
        {
            return Json(Ejecutar(() =>
            {
                formato.UsuarioRegistro = Sesion.Usuario();
                return coleccion.proxyFormato.Guardar(formato);
            })
           , JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult EliminarFormato(FormatoDto formato)
        {
            return Json(Ejecutar(() =>
            coleccion.proxyFormato.Eliminar(formato.CodigoDocumento))
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerReglamento()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyReglamento.Obtener())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarReglamento(ReglamentoDto reglamento)
        {
            return Json(Ejecutar(() =>
            {
                reglamento.UsuarioRegistro = Sesion.Usuario();
                return coleccion.proxyReglamento.Guardar(reglamento);
            })
           , JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult EliminarReglamento(ReglamentoDto reglamento)
        {
            return Json(Ejecutar(() =>
            coleccion.proxyReglamento.Eliminar(reglamento.CodigoDocumento))
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerRequisito()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyRequisito.Obtener())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarRequisito(RequisitoDto requisito)
        {
            return Json(Ejecutar(() =>
            {
                requisito.UsuarioRegistro = Sesion.Usuario();
                return coleccion.proxyRequisito.Guardar(requisito);
            })
           , JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult EliminarRequisito(RequisitoDto requisito)
        {
            return Json(Ejecutar(() =>
            coleccion.proxyRequisito.Eliminar(requisito.CodigoDocumento))
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerBoletin()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyBoletin.Obtener())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarBoletin(BoletinDto boletin)
        {
            return Json(Ejecutar(() =>
            {
                boletin.UsuarioRegistro = Sesion.Usuario();
                return coleccion.proxyBoletin.Guardar(boletin);
            })
            , JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult EliminarBoletin(BoletinDto boletin)
        {
            return Json(Ejecutar(() =>
            coleccion.proxyBoletin.Eliminar(boletin.CodigoDocumento))
            , JsonRequestBehavior.AllowGet);
        }
    }
}