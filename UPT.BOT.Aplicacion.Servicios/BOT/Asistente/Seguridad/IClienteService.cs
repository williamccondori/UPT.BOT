using UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad
{
    public interface IClienteService
    {
        bool Guardar(ClienteDto ClienteDto);
    }
}
