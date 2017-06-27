using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Encuesta;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Encuesta;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Encuesta
{
    [RoutePrefix("api/v1/asistente/respuesta")]
    public class BotRespuestaController : BaseApiController
    {
        private readonly IRespuestaService servicioRespuesta;

        public BotRespuestaController()
        {
            servicioRespuesta = new RespuestaService();
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(RespuestasDto respuesta)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicioRespuesta.Guardar(respuesta));
            });
        }
    }
}