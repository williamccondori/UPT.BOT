using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Publicacion
{
    public interface IEventoService
    {
        bool Eliminar(object id);
        bool Guardar(EventoDto evento);
        IList<EventoDto> Obtener();
    }
}
