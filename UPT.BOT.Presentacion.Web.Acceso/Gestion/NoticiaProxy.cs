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

        public RespuestaDto<List<NoticiaConsultaDto>> Obtener()
        {
            return agenteApi.Ejecutar<List<NoticiaConsultaDto>>("Noticia");
        }

        public RespuestaDto<object> Guardar(NoticiaRegistroDto aoNoticia)
        {
            return agenteApi.Ejecutar<object>("Noticia", RestSharp.Method.POST, null, new object[] { aoNoticia });
        }

        public RespuestaDto<object> Eliminar(NoticiaRegistroDto aoNoticia)
        {
            return agenteApi.Ejecutar<object>("Noticia", RestSharp.Method.DELETE, null, new object[] { aoNoticia });
        }
    }
}
