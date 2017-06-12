using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Analisis
{
    public interface IClienteService
    {
        IList<ClienteDto> Obtener();
        IList<GraficoDto> ObtenerNumeroMensajes();
    }
}
