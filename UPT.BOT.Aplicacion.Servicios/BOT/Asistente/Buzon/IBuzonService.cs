using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Buzon
{
    public interface IBuzonService
    {
        bool Guardar(BuzonDto buzon);
        IList<TipoBuzonDto> ObtenerTipo();
    }
}
