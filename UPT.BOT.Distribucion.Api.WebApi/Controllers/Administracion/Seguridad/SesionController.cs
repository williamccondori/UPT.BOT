using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Seguridad;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Configuracion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Seguridad
{
    public class SesionController : BaseApiController
    {
        private readonly IUsuarioService goUsuarioService;

        public SesionController()
        {
            goUsuarioService = new UsuarioService();
        }

        [HttpPost]
        public RespuestaApi<bool> Post([FromBody]SesionDto aoSesion)
        {
            return Ejecutar(() =>
            {
                return new RespuestaApi<bool>(goUsuarioService.Verificar(aoSesion.Usuario, aoSesion.Password));
            });
        }
    }
}