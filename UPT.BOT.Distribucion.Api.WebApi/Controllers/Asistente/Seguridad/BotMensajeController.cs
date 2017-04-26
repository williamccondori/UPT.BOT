using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Seguridad;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Seguridad
{
    public class BotMensajeController : BaseApiController
    {
        private readonly IMensajeService goMensajeService;

        public BotMensajeController()
        {
            goMensajeService = new MensajeService();
        }
        [HttpPost]
        public RespuestaApi<bool> Post(MensajeDto aoMensajeDto)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goMensajeService.Guardar(aoMensajeDto));
            });
        }
    }
}
