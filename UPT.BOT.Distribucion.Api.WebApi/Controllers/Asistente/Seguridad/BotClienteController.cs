using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Seguridad;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Seguridad
{
    public class BotClienteController : BaseApiController
    {
        private readonly IClienteService goClienteService;

        public BotClienteController()
        {
            goClienteService = new ClienteService();
        }

        [HttpPost]
        public RespuestaApi<bool> Post(ClienteDto aoClienteDto)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goClienteService.Guardar(aoClienteDto));
            });
        }
    }
}