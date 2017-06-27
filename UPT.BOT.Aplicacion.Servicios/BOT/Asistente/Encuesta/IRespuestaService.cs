using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Encuesta
{
    public interface IRespuestaService
    {
        bool Guardar(RespuestasDto respuesta);
    }
}
