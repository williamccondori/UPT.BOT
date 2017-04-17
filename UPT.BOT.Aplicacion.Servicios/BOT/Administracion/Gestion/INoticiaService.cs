using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion
{
    public interface INoticiaService
    {
        IList<NoticiaConsultaDto> Consultar();
        bool Guardar(NoticiaRegistroDto Noticia);
        bool Eliminar(long Id);
    }
}
