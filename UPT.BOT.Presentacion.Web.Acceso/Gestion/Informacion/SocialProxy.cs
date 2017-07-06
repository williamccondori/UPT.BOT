using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Informacion
{
    public class SocialProxy : BaseProxy
    {
        public SocialProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<List<SocialDto>> Obtener()
        {
            return Ejecutar<List<SocialDto>>("social");
        }

        public Response<bool> Guardar(SocialDto social)
        {
            return Ejecutar<bool>("social", Metodo.Post, new object[] { social });
        }

        public Response<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("social/{0}", id), Metodo.Delete);
        }
    }
}
