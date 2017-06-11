using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Publicacion
{
    [RoutePrefix("api/v1/asistente/publicacion")]
    public class BotPublicacionController : BaseApiController
    {
        private readonly IPublicacionService servicioPublicacion;

        public BotPublicacionController()
        {
            servicioPublicacion = new PublicacionService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<PublicacionDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<PublicacionDto>>(servicioPublicacion.Obtener());
            });
        }
    }
}