using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Publicacion
{
    [RoutePrefix("api/v1/asistente/actualidad")]
    public class BotActualidadController : BaseApiController
    {
        private readonly IActualidadService servicioActualidad;

        public BotActualidadController()
        {
            servicioActualidad = new ActualidadService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<ActualidadDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<ActualidadDto>>(servicioActualidad.Obtener());
            });
        }
    }
}