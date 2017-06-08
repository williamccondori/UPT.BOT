using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Documento
{
    public interface IFormatoService
    {
        bool Eliminar(object id);
        bool Guardar(FormatoDto formato);
        IList<FormatoDto> Obtener();
    }
}
