using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT
{
    public interface IConfiguracionService
    {
        bool Guardar(ConfiguracionDto configuracion);
    }
}
