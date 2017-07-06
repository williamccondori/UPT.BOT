using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Configuracion
{
    public class UsuarioProxy : BaseProxy
    {
        public UsuarioProxy(string ruta, string usuario) : base(ruta, usuario)
        {

        }

        public Response<bool> Agregar(UsuarioDto usuario)
        {
            return Ejecutar<bool>("usuario", Metodo.Post, usuario);
        }

        public Response<bool> ValidarAccesoSistema(UsuarioDto usuario)
        {
            return Ejecutar<bool>("usuario/acceso/sistema", Metodo.Post, usuario);
        }
    }
}
