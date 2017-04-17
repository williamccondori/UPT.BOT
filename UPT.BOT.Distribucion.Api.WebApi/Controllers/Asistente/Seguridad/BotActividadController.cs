using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Seguridad;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Seguridad
{
    public class BotActividadController : BaseApiController
    {
        private readonly IActividadService goActividadService;

        public BotActividadController()
        {
            goActividadService = new ActividadService();
        }
        [HttpPost]
        public RespuestaApi<bool> Post(ActividadDto aoActividadDto)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goActividadService.Guardar(aoActividadDto));
            });
        }
    }
}
