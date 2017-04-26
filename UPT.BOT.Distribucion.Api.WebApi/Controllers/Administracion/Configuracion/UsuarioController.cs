using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Configuracion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Configuracion
{
    public class UsuarioController : BaseApiController
    {
        private readonly IUsuarioService goUsuarioService;

        public UsuarioController()
        {
            goUsuarioService = new UsuarioService();
        }

        [HttpGet]
        public RespuestaApi<IList<UsuarioConsultaDto>> Get()
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<IList<UsuarioConsultaDto>>(goUsuarioService.Obtener());
            });
        }

        [HttpPost]
        public RespuestaApi<bool> Post([FromBody]UsuarioRegistroDto aoUsuario)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goUsuarioService.Guardar(aoUsuario));
            });
        }

        [HttpDelete]
        public RespuestaApi<bool> Delete(long algId)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goUsuarioService.Eliminar(algId));
            });
        }
    }
}