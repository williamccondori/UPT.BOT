using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.PlanEstudio;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Planestudio;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.PlanEstudio
{
    [RoutePrefix("api/v1/asistente/perfil_profesional")]
    public class BotPerfilProfesionalController : BaseApiController
    {
        private readonly IPerfilProfesionalService servicioPerfilProfesional;

        public BotPerfilProfesionalController()
        {
            servicioPerfilProfesional = new PerfilProfesionalService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<PerfilProfesionalDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<PerfilProfesionalDto>>(servicioPerfilProfesional.Obtener());
            });
        }
    }
}