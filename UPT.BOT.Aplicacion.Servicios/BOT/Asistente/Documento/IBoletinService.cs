using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Documento
{
    public interface IBoletinService
    {
        IList<BoletinDto> Obtener();
    }
}
