using System;
using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.Shared;
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
    }
}