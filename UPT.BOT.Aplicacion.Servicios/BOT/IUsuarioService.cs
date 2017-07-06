using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT
{
    public interface IUsuarioService
    {
        bool ValidarAccesoSistema(UsuarioDto usuario);
    }
}
