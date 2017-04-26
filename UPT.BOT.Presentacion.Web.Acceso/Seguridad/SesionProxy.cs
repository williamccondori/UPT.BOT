using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Seguridad;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Seguridad
{
    public class SesionProxy : BaseProxy
    {
        public SesionProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        public RespuestaApi<object> Verificar(SesionDto aoSesion)
        {
            return goAgente.Ejecutar<object>("Sesion", RestSharp.Method.POST, null, new object[] { aoSesion });
        }
    }
}
