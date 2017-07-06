using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : BaseApiController
    {
        private readonly IUsuarioService _servicioUsuario;

        public UsuarioController()
        {
            _servicioUsuario = new UsuarioService();
        }

        [HttpPost, Route("acceso/sistema")]
        public Response<bool> ValidarAccesoSistema([FromBody]UsuarioDto usuario)
        {
            return Ejecutar(() =>
            {
                return new Response<bool>(_servicioUsuario.ValidarAccesoSistema(usuario));
            });
        }
    }
}