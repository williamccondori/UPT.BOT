using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT
{
    public interface IMensajeService
    {
        bool Guardar(MensajeDto mensaje);
    }
}
