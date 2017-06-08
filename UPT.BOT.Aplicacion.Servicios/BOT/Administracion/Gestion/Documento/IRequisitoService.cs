using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Documento
{
    public interface IRequisitoService
    {
        bool Eliminar(object id);
        bool Guardar(RequisitoDto reglamento);
        IList<RequisitoDto> Obtener();
    }
}
