using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Publicacion
{
    public interface IActualidadService
    {
        bool Eliminar(object id);
        bool Guardar(ActualidadDto actualidad);
        IList<ActualidadDto> Obtener();
    }
}
