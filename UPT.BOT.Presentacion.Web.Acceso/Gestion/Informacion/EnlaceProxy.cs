using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Informacion
{
    public class EnlaceProxy : BaseProxy
    {
        public EnlaceProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public RespuestaDto<List<EnlaceImportanteDto>> Obtener()
        {
            return Ejecutar<List<EnlaceImportanteDto>>("enlace");
        }

        public RespuestaDto<bool> Guardar(EnlaceImportanteDto enlace)
        {
            return Ejecutar<bool>("enlace", Metodo.Post, new object[] { enlace });
        }

        public RespuestaDto<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("enlace/{0}", id), Metodo.Delete);
        }
    }
}
