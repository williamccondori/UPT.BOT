using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Buzon;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Buzon;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Buzon
{
    [RoutePrefix("api/v1/asistente/buzon")]
    public class BotBuzonController : BaseApiController
    {
        private readonly IBuzonService servicioBuzon;

        public BotBuzonController()
        {
            servicioBuzon = new BuzonService();
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(BuzonDto buzon)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicioBuzon.Guardar(buzon));
            });
        }

        [HttpGet, Route("Tipo")]
        public RespuestaDto<IList<TipoBuzonDto>> ObtenerTipo()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<TipoBuzonDto>>(servicioBuzon.ObtenerTipo());
            });
        }
    }
}
