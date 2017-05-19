using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Publicacion
{
    [RoutePrefix("api/v1/asistente/evento")]
    public class BotEventoController : BaseApiController
    {
        private readonly IEventoService servicioEvento;

        public BotEventoController()
        {
            servicioEvento = new EventoService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<EventoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<EventoDto>>(servicioEvento.Obtener());
            });
        }
    }
}