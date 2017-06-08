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


        // evento

        [HttpGet]
        public ActionResult Evento() => View();

        [HttpGet]
        public JsonResult ObtenerEvento() => Json(Ejecutar(() => coleccion.proxyEvento.Obtener()), JsonRequestBehavior.AllowGet);

        [HttpGet]
        public JsonResult ObtenerConvenio()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyConvenio.Obtener())
            , JsonRequestBehavior.AllowGet);
        }



        // gestion de publicaciones

        [HttpGet]
        public ActionResult Publicacion()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerActualidad()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyActualidad.Obtener())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarActualidad(ActualidadDto actualidad)
        {
            return Json(Ejecutar(() =>
            {
                actualidad.UsuarioRegistro = Sesion.Usuario();
                return coleccion.proxyActualidad.Guardar(actualidad);
            })
           , JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult EliminarActualidad(ActualidadDto actualidad)
        {
            return Json(Ejecutar(() =>
            coleccion.proxyActualidad.Eliminar(actualidad.CodigoPublicacion))
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerComunicado()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyComunicado.Obtener())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarComunicado(ComunicadoDto comunicado)
        {
            return Json(Ejecutar(() =>
            {
                comunicado.UsuarioRegistro = Sesion.Usuario();
                return coleccion.proxyComunicado.Guardar(comunicado);
            })
           , JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult EliminarComunicado(ComunicadoDto comunicado)
        {
            return Json(Ejecutar(() =>
            coleccion.proxyComunicado.Eliminar(comunicado.CodigoPublicacion))
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerGaleria()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyGaleria.Obtener())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarGaleria(GaleriaDto galeria)
        {
            return Json(Ejecutar(() =>
            {
                galeria.UsuarioRegistro = Sesion.Usuario();
                return coleccion.proxyGaleria.Guardar(galeria);
            })
           , JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult EliminarGaleria(GaleriaDto galeria)
        {
            return Json(Ejecutar(() =>
            coleccion.proxyGaleria.Eliminar(galeria.CodigoGaleria))
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerPublicacion()
        {
            return Json(Ejecutar(() =>
            coleccion.proxyPublicacion.Obtener())
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPublicacion(PublicacionDto publicacion)
        {
            return Json(Ejecutar(() =>
            {
                publicacion.UsuarioRegistro = Sesion.Usuario();
                return coleccion.proxyPublicacion.Guardar(publicacion);
            })
           , JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult EliminarPublicacion(PublicacionDto publicacion)
        {
            return Json(Ejecutar(() =>
            coleccion.proxyPublicacion.Eliminar(publicacion.CodigoPublicacion))
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