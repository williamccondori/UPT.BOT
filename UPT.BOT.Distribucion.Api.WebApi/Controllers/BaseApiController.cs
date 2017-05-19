using System;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {

        public const string Predeterminado = "";

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
    }
}