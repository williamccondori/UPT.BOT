using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Publicacion
{
    public class ActualidadProxy : BaseProxy
    {
        public ActualidadProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<bool> Eliminar(long codigoPublicacion)
        {
            return Ejecutar<bool>(string.Format("actualidad/{0}", codigoPublicacion), Metodo.Delete);
        }

        public Response<bool> Guardar(ActualidadDto actualidad)
        {
            return Ejecutar<bool>("actualidad", Metodo.Post, actualidad);
        }

        public Response<List<ActualidadDto>> Obtener()
        {
            return Ejecutar<List<ActualidadDto>>("actualidad");
        }
    }
}
