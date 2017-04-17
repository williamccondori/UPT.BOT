using System;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
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