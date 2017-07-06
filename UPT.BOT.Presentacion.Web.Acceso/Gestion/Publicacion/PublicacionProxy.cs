using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Publicacion
{
    public class PublicacionProxy : BaseProxy
    {
        public PublicacionProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<bool> Eliminar(long codigoPublicacion)
        {
            return Ejecutar<bool>(string.Format("publicacion/{0}", codigoPublicacion), Metodo.Delete);
        }

        public Response<bool> Guardar(PublicacionDto publicacion)
        {
            return Ejecutar<bool>("publicacion", Metodo.Post, publicacion);
        }

        public Response<List<PublicacionDto>> Obtener()
        {
            return Ejecutar<List<PublicacionDto>>("publicacion");
        }
    }
}
