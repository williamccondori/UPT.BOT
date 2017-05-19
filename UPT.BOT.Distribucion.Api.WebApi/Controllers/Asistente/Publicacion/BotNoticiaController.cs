using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Publicacion
{
    [RoutePrefix("api/v1/asistente/noticia")]
    public class BotNoticiaController : BaseApiController
    {
        private readonly INoticiaService servicioNoticia;

        public BotNoticiaController()
        {
            servicioNoticia = new NoticiaService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<NoticiaDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<NoticiaDto>>(servicioNoticia.Obtener());
            });
        }
    }
}