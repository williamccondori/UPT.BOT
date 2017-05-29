using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Informacion
{
    [RoutePrefix("api/v1/asistente/nosotros")]
    public class BotNosotrosController : BaseApiController
    {
        private readonly INosotrosService servicioNosotros;

        public BotNosotrosController()
        {
            servicioNosotros = new NosotrosService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<NosotrosDto> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<NosotrosDto>(servicioNosotros.Obtener());
            });
        }
    }
}
