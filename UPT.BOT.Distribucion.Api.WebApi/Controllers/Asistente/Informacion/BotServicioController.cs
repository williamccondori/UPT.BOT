using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Informacion
{
    [RoutePrefix("api/v1/asistente/servicio")]
    public class BotServicioController : BaseApiController
    {
        private readonly IServicioService servicioServicio;

        public BotServicioController()
        {
            servicioServicio = new ServicioService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<List<ServicioDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<List<ServicioDto>>(servicioServicio.Obtener());
            });
        }
    }
}
