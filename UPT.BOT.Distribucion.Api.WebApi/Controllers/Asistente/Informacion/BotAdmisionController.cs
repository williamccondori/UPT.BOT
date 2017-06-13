using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Informacion
{
    [RoutePrefix("api/v1/asistente/admision")]
    public class BotAdmisionController : BaseApiController
    {
        private readonly IAdmisionService servicioAdmision;

        public BotAdmisionController()
        {
            servicioAdmision = new AdmisionService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<AdmisionDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<AdmisionDto>>(servicioAdmision.Obtener());
            });
        }
    }
}