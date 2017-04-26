using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion
{
    public class NoticiaProxy : BaseProxy
    {
        public NoticiaProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        public RespuestaApi<List<NoticiaConsultaDto>> Obtener()
        {
            return goAgente.Ejecutar<List<NoticiaConsultaDto>>("Noticia");
        }

        public RespuestaApi<object> Guardar(NoticiaRegistroDto aoNoticia)
        {
            return goAgente.Ejecutar<object>("Noticia", RestSharp.Method.POST, null, new object[] { aoNoticia });
        }

        public RespuestaApi<object> Eliminar(NoticiaRegistroDto aoNoticia)
        {
            return goAgente.Ejecutar<object>("Noticia", RestSharp.Method.DELETE, null, new object[] { aoNoticia });
        }
    }
}
