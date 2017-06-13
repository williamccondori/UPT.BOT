using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Informacion
{
    [RoutePrefix("api/v1/asistente/direccion")]
    public class BotDireccionController : BaseApiController
    {
        private readonly IDireccionService servicioDireccion;

        public BotDireccionController()
        {
            servicioDireccion = new DireccionService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<DireccionDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<DireccionDto>>(servicioDireccion.Obtener());
            });
        }
    }
}