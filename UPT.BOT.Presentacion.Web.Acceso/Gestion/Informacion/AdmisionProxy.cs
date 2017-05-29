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

        public RespuestaDto<List<AdmisionDto>> Obtener()
        {
            return Ejecutar<List<AdmisionDto>>("admision");
        }

        public RespuestaDto<bool> Guardar(AdmisionDto admision)
        {
            return Ejecutar<bool>("admision", Metodo.Post, new object[] { admision });
        }

        public RespuestaDto<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("admision/{0}", id), Metodo.Delete);
        }
    }
}
