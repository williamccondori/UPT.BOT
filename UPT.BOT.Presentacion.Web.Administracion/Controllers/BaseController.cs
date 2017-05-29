using System;
using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Presentacion.Web.Administracion.Seguridad;
using UPT.BOT.Presentacion.Web.Administracion.Utilidades;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class BaseController : Controller
    {
        protected readonly string ruta;

        public BaseController()
        {
            ruta = VariableConfiguracion.RutaApi();
        }

        protected RespuestaDto<T> Ejecutar<T>(Func<RespuestaDto<T>> aoAccion)
        {
            try
            {
                return aoAccion();
            }
            catch (ApplicationException loExepcion)
            {
                return new RespuestaDto<T>(loExepcion.Message, loExepcion.StackTrace);
            }
            catch (Exception loExepcion)
            {
                return new RespuestaDto<T>(loExepcion.Message, loExepcion.StackTrace);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext aoContexto)
        {
            string controlador = aoContexto.ActionDescriptor.ControllerDescriptor.ControllerName;
            string accion = aoContexto.ActionDescriptor.ActionName;

            if (!Sesion.ValidarSesion())
            {
                TempData["MensajeError"] = "Su sesión ha expirado, por favor, vuelva a validar sus credenciales.";

                aoContexto.Result = new RedirectResult("~/Seguridad/Login");

                return;
            }

            if (aoContexto.HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {

            }
        }
    }
}