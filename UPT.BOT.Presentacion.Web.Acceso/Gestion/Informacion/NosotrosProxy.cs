using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Informacion
{
    public class NosotrosProxy : BaseProxy
    {
        public NosotrosProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public RespuestaDto<NosotrosDto> Obtener()
        {
            return Ejecutar<NosotrosDto>("nosotros");
        }

        public RespuestaDto<bool> Guardar(NosotrosDto nosotros)
        {
            return Ejecutar<bool>("nosotros", Metodo.Post, new object[] { nosotros });
        }

        public RespuestaDto<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("nosotros/{0}", id), Metodo.Delete);
        }
    }
}
