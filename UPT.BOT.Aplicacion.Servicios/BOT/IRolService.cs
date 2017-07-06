using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT
{
    public interface IRolService
    {
        IList<RolDto> Obtener();
        bool Guardar(RolDto rol);
    }
}
