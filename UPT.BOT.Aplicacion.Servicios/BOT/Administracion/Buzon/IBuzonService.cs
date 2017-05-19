using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Buzon
{
    public interface IBuzonService
    {
        IList<BuzonDto> Obtener();
    }
}
