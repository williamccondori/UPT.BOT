using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Analisis;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Analisis;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Analisis
{
    [RoutePrefix("api/v1/administracion/cliente")]
    public class ClienteController : BaseApiController
    {
        private readonly IClienteService servicio;

        public ClienteController()
        {
            servicio = new ClienteService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<ClienteDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<ClienteDto>>(servicio.Obtener());
            });
        }

        [HttpGet, Route("mensajes/numero")]
        public RespuestaDto<IList<GraficoDto>> ObtenerMensajesNumero()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<GraficoDto>>(servicio.ObtenerNumeroMensajes());
            });
        }
    }
}