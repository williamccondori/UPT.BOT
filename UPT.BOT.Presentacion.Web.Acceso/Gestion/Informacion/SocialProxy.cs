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

        public RespuestaDto<List<SocialDto>> Obtener()
        {
            return Ejecutar<List<SocialDto>>("social");
        }

        public RespuestaDto<bool> Guardar(SocialDto social)
        {
            return Ejecutar<bool>("social", Metodo.Post, new object[] { social });
        }

        public RespuestaDto<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("social/{0}", id), Metodo.Delete);
        }
    }
}
