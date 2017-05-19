using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Documento;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Documento;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Documento
{
    [RoutePrefix("api/v1/asistente/boletin")]
    public class BotBoletinController : BaseApiController
    {
        private readonly IBoletinService servicioBoletin;

        public BotBoletinController()
        {
            servicioBoletin = new BoletinService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<BoletinDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<BoletinDto>>(servicioBoletin.Obtener());
            });
        }
    }
}
