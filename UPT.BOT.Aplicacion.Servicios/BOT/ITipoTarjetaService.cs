using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT
{
    public interface ITipoTarjetaService
    {
        IList<TipoTarjetaDto> Obtener();
    }
}
