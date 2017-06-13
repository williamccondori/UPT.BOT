using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Encuesta;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Encuesta;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Encuesta
{
    [RoutePrefix("api/v1/asistente/encuesta")]
    public class BotEncuestaController : BaseApiController
    {
        private readonly IEncuestaService servicioEncuesta;

        public BotEncuestaController()
        {
            servicioEncuesta = new EncuestaService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<EncuestaDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<EncuestaDto>>(servicioEncuesta.Obtener());
            });
        }

        [HttpGet, Route("codigo/{codigoEncuesta}")]
        public RespuestaDto<EncuestaDto> ObtenerXCodigo(long codigoEncuesta)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<EncuestaDto>(servicioEncuesta.ObtenerXCodigo(codigoEncuesta));
            });
        }
    }
}
