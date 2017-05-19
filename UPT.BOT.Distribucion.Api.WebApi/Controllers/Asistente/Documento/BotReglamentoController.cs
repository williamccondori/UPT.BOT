using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Documento;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Documento;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Documento
{
    [RoutePrefix("api/v1/asistente/reglamento")]
    public class BotReglamentoController : BaseApiController
    {
        private readonly IReglamentoService servicioReglamento;

        public BotReglamentoController()
        {
            servicioReglamento = new ReglamentoService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<ReglamentoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<ReglamentoDto>>(servicioReglamento.Obtener());
            });
        }
    }
}
