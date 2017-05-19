using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Documento;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Documento;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Documento
{
    [RoutePrefix("api/v1/asistente/formato")]
    public class BotFormatoController : BaseApiController
    {
        private readonly IFormatoService servicioFormato;

        public BotFormatoController()
        {
            servicioFormato = new FormatoService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<FormatoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<FormatoDto>>(servicioFormato.Obtener());
            });
        }
    }
}
