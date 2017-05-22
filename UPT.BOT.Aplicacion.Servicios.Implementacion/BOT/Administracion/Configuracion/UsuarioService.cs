using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Configuracion
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        UsuarioRepository repositorioUsuario;

        public UsuarioService()
        {
            repositorioUsuario = new UsuarioRepository(contexto);
        }

        public bool Validar(UsuarioDto usuario)
        {
            return repositorioUsuario.Verificar(usuario.DescripcionUsuario, usuario.DescripcionPassword);
        }
    }
}
