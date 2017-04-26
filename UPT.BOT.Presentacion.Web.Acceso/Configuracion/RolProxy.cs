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

        public RespuestaApi<List<RolConsultaDto>> Obtener()
        {
            return goAgente.Ejecutar<List<RolConsultaDto>>("Rol");
        }

        public RespuestaApi<object> Guardar(RolRegistroDto aoRol)
        {
            return goAgente.Ejecutar<object>("Rol", RestSharp.Method.POST, null, new object[] { aoRol });
        }
    }
}
