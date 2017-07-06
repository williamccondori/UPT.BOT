using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Documento
{
    public class ReglamentoProxy : BaseProxy
    {
        public ReglamentoProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<bool> Eliminar(long codigoDocumento)
        {
            return Ejecutar<bool>(string.Format("reglamento/{0}", codigoDocumento), Metodo.Delete);
        }

        public Response<bool> Guardar(ReglamentoDto reglamento)
        {
            return Ejecutar<bool>("reglamento", Metodo.Post, reglamento);
        }

        public Response<List<ReglamentoDto>> Obtener()
        {
            return Ejecutar<List<ReglamentoDto>>("reglamento");
        }
    }
}
