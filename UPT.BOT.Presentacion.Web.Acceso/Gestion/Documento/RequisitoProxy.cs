using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Documento
{
    public class RequisitoProxy : BaseProxy
    {
        public RequisitoProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<bool> Eliminar(long codigoDocumento)
        {
            return Ejecutar<bool>(string.Format("requisito/{0}", codigoDocumento), Metodo.Delete);
        }

        public Response<bool> Guardar(RequisitoDto requisito)
        {
            return Ejecutar<bool>("requisito", Metodo.Post, requisito);
        }

        public Response<List<RequisitoDto>> Obtener()
        {
            return Ejecutar<List<RequisitoDto>>("requisito");
        }
    }
}
