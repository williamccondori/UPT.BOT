using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Documento;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Documento;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Documento
{
    [RoutePrefix("api/v1/asistente/requisito")]
    public class BotRequisitoController : BaseApiController
    {
        private readonly IRequisitoService servicioRequisito;

        public BotRequisitoController()
        {
            servicioRequisito = new RequisitoService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<RequisitoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<RequisitoDto>>(servicioRequisito.Obtener());
            });
        }
    }
}