using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Informacion
{
    public class AdmisionProxy : BaseProxy
    {
        public AdmisionProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<List<AdmisionDto>> Obtener()
        {
            return Ejecutar<List<AdmisionDto>>("admision");
        }

        public Response<bool> Guardar(AdmisionDto admision)
        {
            return Ejecutar<bool>("admision", Metodo.Post, new object[] { admision });
        }

        public Response<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("admision/{0}", id), Metodo.Delete);
        }
    }
}
