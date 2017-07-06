using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/tipo_tarjeta")]
    public class TipoTarjetaController : BaseApiController
    {
        private readonly ITipoTarjetaService _servicioTipoTarjeta;

        public TipoTarjetaController()
        {
            _servicioTipoTarjeta = new TipoTarjetaService();
        }

        [HttpGet, Route(Predeterminado)]
        public Response<IList<TipoTarjetaDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new Response<IList<TipoTarjetaDto>>(_servicioTipoTarjeta.Obtener());
            });
        }
    }
}