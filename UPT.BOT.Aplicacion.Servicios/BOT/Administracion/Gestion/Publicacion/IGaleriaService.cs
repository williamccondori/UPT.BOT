using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Publicacion
{
    public interface IGaleriaService
    {
        bool Eliminar(object id);
        bool Guardar(GaleriaDto galeria);
        IList<GaleriaDto> Obtener();
    }
}
