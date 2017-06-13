using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Informacion
{
    [RoutePrefix("api/v1/asistente/acreditacion")]
    public class BotAcreditacionController : BaseApiController
    {
        private readonly IAcreditacionService servicioAcreditacion;

        public BotAcreditacionController()
        {
            servicioAcreditacion = new AcreditacionService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<AcreditacionDto> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<AcreditacionDto>(servicioAcreditacion.Obtener());
            });
        }
    }
}