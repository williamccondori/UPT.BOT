using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Seguridad;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Seguridad
{
    [RoutePrefix("api/v1/asistente/cliente")]
    public class BotClienteController : BaseApiController
    {
        private readonly IClienteService servicioCliente;

        public BotClienteController()
        {
            servicioCliente = new ClienteService();
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(ClienteDto cliente)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicioCliente.Guardar(cliente));
            });
        }
    }
}