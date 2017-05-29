using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Informacion
{
    [RoutePrefix("api/v1/asistente/convenio")]
    public class BotConvenioController : BaseApiController
    {
        private readonly IConvenioService servicioConvenio;

        public BotConvenioController()
        {
            servicioConvenio = new ConvenioService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<List<ConvenioDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<List<ConvenioDto>>(servicioConvenio.Obtener());
            });
        }
    }
}
