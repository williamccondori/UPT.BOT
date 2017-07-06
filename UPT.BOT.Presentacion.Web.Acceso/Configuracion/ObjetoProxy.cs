using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Configuracion
{
    public class ObjetoProxy : BaseProxy
    {
        public ObjetoProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<IList<ObjetoDto>> Obtener()
        {
            return Ejecutar<IList<ObjetoDto>>("objeto");
        }

        public Response<bool> Guardar(ObjetoDto objeto)
        {
            objeto.Usuario = base.usuario;
            return Ejecutar<bool>("objeto", Metodo.Post, objeto);
        }
    }
}
