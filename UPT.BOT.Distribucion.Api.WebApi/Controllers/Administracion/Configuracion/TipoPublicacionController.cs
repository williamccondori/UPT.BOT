using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Configuracion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Configuracion
{
    public class TipoPublicacionController : BaseApiController
    {
        private readonly ITipoPublicacionService goTipoPublicacionService;

        public TipoPublicacionController()
        {
            goTipoPublicacionService = new TipoPublicacionService();
        }

        [HttpGet]
        public object Get()
        {
            return Json(Ejecutar(() =>
            {
                return new RespuestaApi<IList<TipoPublicacionConsultaDto>>(
                    goTipoPublicacionService.Consultar());
            }), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpPost]
        public object Post([FromBody]TipoPublicacionRegistroDto aoTipoPublicacion)
        {
            return Json(Ejecutar(() =>
            {
                return new RespuestaApi<bool>(
                    goTipoPublicacionService.Agregar(aoTipoPublicacion));
            }), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpPut]
        public object Put(int id, [FromBody]TipoPublicacionRegistroDto aoTipoPublicacion)
        {
            return Json(Ejecutar(() =>
            {
                return new RespuestaApi<bool>(
                    goTipoPublicacionService.Modificar(aoTipoPublicacion));
            }), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpDelete]
        public object Delete(long algId)
        {
            return Json(Ejecutar(() =>
            {
                return new RespuestaApi<bool>(
                    goTipoPublicacionService.Eliminar(algId));
            }), new JsonSerializerSettings(), Encoding.UTF8);
        }
    }
}
