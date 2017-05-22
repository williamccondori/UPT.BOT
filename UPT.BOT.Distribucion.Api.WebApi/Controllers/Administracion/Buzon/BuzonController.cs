using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Buzon;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Buzon;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Buzon
{
    [RoutePrefix("api/v1/administracion/buzon")]
    public class BuzonController : BaseApiController
    {
        private readonly IBuzonService servicioBuzon;

        public BuzonController()
        {
            servicioBuzon = new BuzonService();
        }


        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<IList<BuzonDto>> Obtener() => Ejecutar(() => new RespuestaDto<IList<BuzonDto>>(servicioBuzon.Obtener()));
    }
}
