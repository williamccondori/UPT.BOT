using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion
{
    public interface INoticiaService
    {
        IList<NoticiaConsultaBotDto> Consultar();
    }
}
