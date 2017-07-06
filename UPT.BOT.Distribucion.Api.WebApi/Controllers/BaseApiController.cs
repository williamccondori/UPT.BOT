using System;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {

        public const string Predeterminado = "";

        protected Response<T> Ejecutar<T>(Func<Response<T>> funcion)
        {
            try
            {
                return funcion();
            }
            catch (ApplicationException excepcion)
            {
                return new Response<T>(excepcion.Message, excepcion.StackTrace);
            }
            catch (Exception excepcion)
            {
                return new Response<T>(excepcion.Message, excepcion.StackTrace);
            }
        }
    }
}