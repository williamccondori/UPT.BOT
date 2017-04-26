using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Gestion
{
    public class NoticiaController : BaseApiController
    {
        private readonly INoticiaService goNoticiaService;

        public NoticiaController()
        {
            goNoticiaService = new NoticiaService();
        }

        [HttpGet]
        public RespuestaApi<IList<NoticiaConsultaDto>> Get()
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<IList<NoticiaConsultaDto>>(goNoticiaService.Obtener());
            });
        }

        [HttpPost]
        public RespuestaApi<bool> Post([FromBody]NoticiaRegistroDto aoNoticia)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goNoticiaService.Guardar(aoNoticia));
            });
        }

        [HttpDelete]
        public RespuestaApi<bool> Delete([FromBody]NoticiaRegistroDto aoNoticia)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goNoticiaService.Eliminar(aoNoticia.CodigoPublicacion));
            });
        }
    }
}
