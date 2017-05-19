using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Configuracion
{
    public class RolProxy : BaseProxy
    {
        public RolProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        public RespuestaDto<List<RolConsultaDto>> Obtener()
        {
            return agenteApi.Ejecutar<List<RolConsultaDto>>("Rol");
        }

        public RespuestaDto<object> Guardar(RolRegistroDto aoRol)
        {
            return agenteApi.Ejecutar<object>("Rol", RestSharp.Method.POST, null, new object[] { aoRol });
        }
    }
}
