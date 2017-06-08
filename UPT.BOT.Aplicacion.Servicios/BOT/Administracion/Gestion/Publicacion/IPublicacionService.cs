using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Publicacion
{
    public interface IPublicacionService
    {
        bool Eliminar(object id);
        bool Guardar(PublicacionDto publicacion);
        IList<PublicacionDto> Obtener();
    }
}
