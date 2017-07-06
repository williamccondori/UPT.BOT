using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT
{
    public interface ITarjetaService
    {
        bool Guardar(TarjetaDto adjunto);
        IList<TarjetaDto> ObtenerXTipo(string codigoTipo);
        IList<TarjetaDto> ObtenerXTipo(string codigoTipo, int numeroRegistro);
    }
}
