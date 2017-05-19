using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Seguridad;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Configuracion
{
    public class UsuarioProxy : BaseProxy
    {
        public UsuarioProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        public RespuestaDto<UsuarioConsultaDto> Buscar(string usuario)
        {
            return agenteApi.Ejecutar<UsuarioConsultaDto>(string.Format("usuario/{0}", usuario));
        }

        public RespuestaDto<List<UsuarioConsultaDto>> Obtener()
        {
            return agenteApi.Ejecutar<List<UsuarioConsultaDto>>("usuario");
        }

        public RespuestaDto<object> Guardar(UsuarioRegistroDto aoUsuario)
        {
            return agenteApi.Ejecutar<object>("usuario", RestSharp.Method.POST, null, new object[] { aoUsuario });
        }

        public RespuestaDto<object> Verificar(SesionDto aoSesion)
        {
            return agenteApi.Ejecutar<object>("usuario/sesion", RestSharp.Method.POST, null, new object[] { aoSesion });
        }
    }
}
