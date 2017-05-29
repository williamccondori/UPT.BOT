using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Informacion
{
    public class AcreditacionProxy : BaseProxy
    {
        public AcreditacionProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public RespuestaDto<AcreditacionDto> Obtener()
        {
            return Ejecutar<AcreditacionDto>("acreditacion");
        }

        public RespuestaDto<bool> Guardar(AcreditacionDto acreditacion)
        {
            return Ejecutar<bool>("acreditacion", Metodo.Post, new object[] { acreditacion });
        }

        public RespuestaDto<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("acreditacion/{0}", id), Metodo.Delete);
        }
    }
}
