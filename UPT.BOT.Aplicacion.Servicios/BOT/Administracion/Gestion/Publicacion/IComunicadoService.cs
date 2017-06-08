using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Publicacion
{
    public interface IComunicadoService
    {
        bool Eliminar(object id);
        bool Guardar(ComunicadoDto comunicado);
        IList<ComunicadoDto> Obtener();
    }
}
