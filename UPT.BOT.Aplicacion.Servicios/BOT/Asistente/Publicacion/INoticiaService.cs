using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion
{
    public interface INoticiaService
    {
        IList<NoticiaDto> Obtener();
    }
}
