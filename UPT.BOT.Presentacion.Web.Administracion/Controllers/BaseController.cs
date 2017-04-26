using System;
using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Presentacion.Web.Administracion.Seguridad;
using UPT.BOT.Presentacion.Web.Administracion.Utilidades;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class BaseController : Controller
    {
        protected readonly string gsRuta;
        protected readonly string gsVersion;
        protected readonly string gsServicio;

        public BaseController()
        {
            gsRuta = VariableConfiguracion.RutaApi();
            gsVersion = VariableConfiguracion.VersionApi();
            gsServicio = VariableConfiguracion.ServicioApi();
        }

        protected RespuestaApi<T> Ejecutar<T>(Func<RespuestaApi<T>> aoAccion)
        {
            try
            {
                return aoAccion();
            }
            catch (ApplicationException loExepcion)
            {
                return new RespuestaApi<T>(loExepcion.Message, loExepcion.StackTrace);
            }
            catch (Exception loExepcion)
            {
                return new RespuestaApi<T>(loExepcion.Message, loExepcion.StackTrace);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext aoContexto)
        {
            string lsControlador = aoContexto.ActionDescriptor.ControllerDescriptor.ControllerName;
            string lsAccion = aoContexto.ActionDescriptor.ActionName;

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