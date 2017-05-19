using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Seguridad;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Seguridad
{
    [RoutePrefix("api/v1/asistente/mensaje")]
    public class BotMensajeController : BaseApiController
    {
        private readonly IMensajeService servicioMensaje;

        public BotMensajeController()
        {
            servicioMensaje = new MensajeService();
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(MensajeDto mensaje)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicioMensaje.Guardar(mensaje));
            });
        }
    }
}
