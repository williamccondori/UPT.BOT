
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad
{
    public interface IClienteService
    {
        bool Guardar(ClienteDto cliente);
    }
}
