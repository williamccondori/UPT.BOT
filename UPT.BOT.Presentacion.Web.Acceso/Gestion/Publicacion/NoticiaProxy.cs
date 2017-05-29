using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Publicacion
{
    public class NoticiaProxy : BaseProxy
    {
        public NoticiaProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public RespuestaDto<List<NoticiaDto>> Obtener()
        {
            return Ejecutar<List<NoticiaDto>>("noticia");
        }

        public RespuestaDto<bool> Guardar(NoticiaDto noticia)
        {
            return Ejecutar<bool>("noticia", Metodo.Post, new object[] { noticia });
        }

        public RespuestaDto<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("noticia/{0}", id), Metodo.Delete);
        }
    }
}
