using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Configuracion
{
    public class UsuarioProxy : BaseProxy
    {
        public UsuarioProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        public RespuestaApi<List<UsuarioConsultaDto>> Obtener()
        {
            return goAgente.Ejecutar<List<UsuarioConsultaDto>>("Usuario");
        }

        public RespuestaApi<object> Guardar(UsuarioRegistroDto aoUsuario)
        {
            return goAgente.Ejecutar<object>("Usuario", RestSharp.Method.POST, null, new object[] { aoUsuario });
        }
    }
}
