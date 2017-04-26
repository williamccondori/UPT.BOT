using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Configuracion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Configuracion
{
    public class RolController : BaseApiController
    {
        private readonly IRolService goRolService;

        public RolController()
        {
            goRolService = new RolService();
        }

        [HttpGet]
        public RespuestaApi<IList<RolConsultaDto>> Get()
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<IList<RolConsultaDto>>(goRolService.Obtener());
            });
        }

        [HttpPost]
        public RespuestaApi<bool> Post([FromBody]RolRegistroDto aoNoticia)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goRolService.Guardar(aoNoticia));
            });
        }

        [HttpDelete]
        public RespuestaApi<bool> Delete(long algId)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goRolService.Eliminar(algId));
            });
        }
    }
}