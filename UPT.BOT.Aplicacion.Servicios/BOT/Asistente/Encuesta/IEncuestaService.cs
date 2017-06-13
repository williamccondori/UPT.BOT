using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Encuesta
{
    public interface IEncuestaService
    {
        IList<EncuestaDto> Obtener();
        EncuestaDto ObtenerXCodigo(long codigoEncuesta);
    }
}
