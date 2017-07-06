using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Configuracion
{
    public class RolProxy : BaseProxy
    {
        public RolProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<IList<RolDto>> Obtener()
        {
            return Ejecutar<IList<RolDto>>("rol");
        }

        public Response<bool> Guardar(RolDto rol)
        {
            rol.Usuario = base.usuario;
            return Ejecutar<bool>("rol", Metodo.Post, rol);
        }
    }
}
