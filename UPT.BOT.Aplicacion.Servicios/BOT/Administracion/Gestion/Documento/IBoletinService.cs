using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Documento
{
    public interface IBoletinService
    {
        bool Eliminar(object id);
        bool Guardar(BoletinDto boletin);
        IList<BoletinDto> Obtener();
    }
}
