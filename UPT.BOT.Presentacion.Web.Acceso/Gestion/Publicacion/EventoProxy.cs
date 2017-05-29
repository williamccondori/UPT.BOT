using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Publicacion
{
    public class EventoProxy : BaseProxy
    {
        public EventoProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public RespuestaDto<List<EventoDto>> Obtener()
        {
            return Ejecutar<List<EventoDto>>("evento");
        }

        public RespuestaDto<bool> Guardar(EventoDto evento)
        {
            return Ejecutar<bool>("evento", Metodo.Post, new object[] { evento });
        }

        public RespuestaDto<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("evento/{0}", id), Metodo.Delete);
        }
    }
}
