using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.PlanEstudio;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Planestudio;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.PlanEstudio
{
    [RoutePrefix("api/v1/asistente/malla_curricular")]
    public class BotMallaCurricularController : BaseApiController
    {
        private readonly IMallaCurricularService servicioMallaCurricular;

        public BotMallaCurricularController()
        {
            servicioMallaCurricular = new MallaCurricularService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<MallaCurricularDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<MallaCurricularDto>>(servicioMallaCurricular.Obtener());
            });
        }
    }
}