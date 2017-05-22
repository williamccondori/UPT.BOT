using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Configuracion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Configuracion
{
    [RoutePrefix("api/v1/administracion/usuario")]
    public class UsuarioController : BaseApiController
    {
        private readonly IUsuarioService servicioUsuario;

        public UsuarioController()
        {
            servicioUsuario = new UsuarioService();
        }

        [HttpPost, Route("validar")]
        public RespuestaDto<bool> Validar(UsuarioDto usuario) => Ejecutar(() => new RespuestaDto<bool>(servicioUsuario.Validar(usuario)));
    }
}