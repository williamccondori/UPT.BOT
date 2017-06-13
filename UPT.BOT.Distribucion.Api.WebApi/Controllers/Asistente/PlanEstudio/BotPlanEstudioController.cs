using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.PlanEstudio;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Planestudio;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.PlanEstudio
{
    [RoutePrefix("api/v1/asistente/plan_estudio")]
    public class BotPlanEstudioController : BaseApiController
    {
        private readonly IPlanEstudioService servicioPlanEstudio;

        public BotPlanEstudioController()
        {
            servicioPlanEstudio = new PlanEstudioService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<PlanEstudioDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<PlanEstudioDto>>(servicioPlanEstudio.Obtener());
            });
        }
    }
}