using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Informacion
{
    public class ConvenioProxy : BaseProxy
    {
        public ConvenioProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public RespuestaDto<List<ConvenioDto>> Obtener()
        {
            return Ejecutar<List<ConvenioDto>>("convenio");
        }

        public RespuestaDto<bool> Guardar(ConvenioDto convenio)
        {
            return Ejecutar<bool>("convenio", Metodo.Post, new object[] { convenio });
        }

        public RespuestaDto<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("convenio/{0}", id), Metodo.Delete);
        }
    }
}
