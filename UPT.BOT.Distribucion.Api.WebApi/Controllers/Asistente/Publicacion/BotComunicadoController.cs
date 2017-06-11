using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Publicacion
{
    [RoutePrefix("api/v1/asistente/comunicado")]
    public class BotComunicadoController : BaseApiController
    {
        private readonly IComunicadoService servicioComunicado;

        public BotComunicadoController()
        {
            servicioComunicado = new ComunicadoService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<ComunicadoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<ComunicadoDto>>(servicioComunicado.Obtener());
            });
        }
    }
}