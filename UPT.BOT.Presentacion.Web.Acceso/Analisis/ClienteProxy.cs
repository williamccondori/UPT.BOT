using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Analisis
{
    public class ClienteProxy : BaseProxy
    {
        public ClienteProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public RespuestaDto<List<ClienteDto>> Obtener()
        {
            return Ejecutar<List<ClienteDto>>("cliente");
        }

        public RespuestaDto<List<GraficoDto>> ObtenerMensajesNumero()
        {
            return Ejecutar<List<GraficoDto>>("cliente/mensajes/numero");
        }
    }
}
