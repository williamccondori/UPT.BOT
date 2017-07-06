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

        public Response<List<EventoDto>> Obtener()
        {
            return Ejecutar<List<EventoDto>>("evento");
        }

        public Response<bool> Guardar(EventoDto evento)
        {
            return Ejecutar<bool>("evento", Metodo.Post, evento);
        }

        public Response<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("evento/{0}", id), Metodo.Delete);
        }
    }
}
