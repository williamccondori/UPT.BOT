using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _repositorioUsuario;
        public UsuarioService()
        {
            _repositorioUsuario = new UsuarioRepository(contexto);
        }

        public bool ValidarAccesoSistema(UsuarioDto usuario)
        {
            return _repositorioUsuario.ValidarAccesoSistema(usuario.DescripcionUsuario, usuario.DescripcionPassword);
        }
    }
}
