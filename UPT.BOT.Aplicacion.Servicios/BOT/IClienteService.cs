using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT
{
    public interface IClienteService
    {
        bool Guardar(ClienteDto cliente);
    }
}
