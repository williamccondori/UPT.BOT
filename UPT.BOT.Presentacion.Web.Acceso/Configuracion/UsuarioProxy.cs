using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Configuracion
{
    public class UsuarioProxy : BaseProxy
    {
        public UsuarioProxy(string rutaApi) : base(rutaApi)
        {

        }

        public RespuestaDto<bool> Agregar(UsuarioDto usuario) => Ejecutar<bool>("usuario", Metodo.Post, usuario);
        public RespuestaDto<bool> Validar(UsuarioDto usuario) => Ejecutar<bool>("usuario/validar", Metodo.Post, usuario);
    }
}
