using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Analisis
{
    public class MensajeProxy : BaseProxy
    {
        public MensajeProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<List<MensajeDto>> Obtener()
        {
            return Ejecutar<List<MensajeDto>>("mensaje");
        }

        public Response<List<GraficoDto>> ObtenerResumenMes()
        {
            return Ejecutar<List<GraficoDto>>("mensaje/numero/mes");
        }

        public Response<List<GraficoDto>> ObtenerResumenIntenciones()
        {
            return Ejecutar<List<GraficoDto>>("mensaje/intenciones/numero");
        }
    }
}
