using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion
{
    public interface IUsuarioService
    {
        bool Validar(UsuarioDto usuario);
    }
}
