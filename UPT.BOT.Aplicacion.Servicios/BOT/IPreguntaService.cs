using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT
{
    public interface IPreguntaService
    {
        bool Guardar(PreguntaDto pregunta);
        IList<PreguntaDto> Obtener();
    }
}
