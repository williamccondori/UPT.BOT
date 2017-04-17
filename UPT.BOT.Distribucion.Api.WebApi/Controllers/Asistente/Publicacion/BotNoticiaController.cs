using System.Collections.Generic;
using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Publicacion
{
    public class BotNoticiaController : BaseApiController
    {
        private readonly INoticiaService goNoticiaService;

        public BotNoticiaController()
        {
            goNoticiaService = new NoticiaService();
        }

        [HttpGet]
        public RespuestaApi<IList<NoticiaConsultaBotDto>> Get()
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<IList<NoticiaConsultaBotDto>>(goNoticiaService.Consultar());
            });
        }
    }
}