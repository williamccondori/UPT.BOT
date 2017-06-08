using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Documento
{
    public class BoletinProxy : BaseProxy
    {
        public BoletinProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public RespuestaDto<bool> Eliminar(long codigoDocumento)
        {
            return Ejecutar<bool>(string.Format("boletin/{0}", codigoDocumento), Metodo.Delete);
        }

        public RespuestaDto<bool> Guardar(BoletinDto boletin)
        {
            return Ejecutar<bool>("boletin", Metodo.Post, boletin);
        }

        public RespuestaDto<List<BoletinDto>> Obtener()
        {
            return Ejecutar<List<BoletinDto>>("boletin");
        }
    }
}
