using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/mensaje")]
    public class MensajeController : BaseApiController
    {
        private readonly IMensajeService _servicioMensaje;
        public MensajeController()
        {
            _servicioMensaje = new MensajeService();
        }

        [HttpPost, Route(Predeterminado)]
        public Response<bool> Guardar(MensajeDto mensaje)
        {
            return Ejecutar(() =>
            {
                return new Response<bool>(_servicioMensaje.Guardar(mensaje));
            });
        }
    }
}