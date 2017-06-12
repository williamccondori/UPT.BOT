using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Analisis
{
    public interface IMensajeService
    {
        IList<GraficoDto> ObtenerNumeroTotalMes();
        IList<GraficoDto> ObtenerIntenciones();
    }
}
