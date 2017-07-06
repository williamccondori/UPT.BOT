using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Documento
{
    public class FormatoProxy : BaseProxy
    {
        public FormatoProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<bool> Eliminar(long codigoDocumento)
        {
            return Ejecutar<bool>(string.Format("formato/{0}", codigoDocumento), Metodo.Delete);
        }

        public Response<bool> Guardar(FormatoDto formato)
        {
            return Ejecutar<bool>("formato", Metodo.Post, formato);
        }

        public Response<List<FormatoDto>> Obtener()
        {
            return Ejecutar<List<FormatoDto>>("formato");
        }
    }
}
