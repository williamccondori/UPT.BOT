using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/tarjeta")]
    public class TarjetaController : BaseApiController
    {
        private readonly ITarjetaService _servicioTarjeta;
        public TarjetaController()
        {
            _servicioTarjeta = new TarjetaService();
        }

        [HttpPost, Route(Predeterminado)]
        public Response<bool> Guardar(TarjetaDto tarjeta)
        {
            return Ejecutar(() =>
            {
                return new Response<bool>(_servicioTarjeta.Guardar(tarjeta));
            });
        }

        [HttpGet, Route("tipo/{codigoTipo}")]
        public Response<IList<TarjetaDto>> ObtenerXTipo(string codigoTipo)
        {
            return Ejecutar(() =>
            {
                return new Response<IList<TarjetaDto>>(_servicioTarjeta.ObtenerXTipo(codigoTipo));
            });
        }

        [HttpGet, Route("tipo/{codigoTipo}/{numeroRegistro}")]
        public Response<IList<TarjetaDto>> ObtenerXTipo(string codigoTipo, int numeroRegistro)
        {
            return Ejecutar(() =>
            {
                return new Response<IList<TarjetaDto>>(_servicioTarjeta.ObtenerXTipo(codigoTipo, numeroRegistro));
            });
        }
    }
}
