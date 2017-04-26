using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion
{
    public interface IRolService
    {
        List<RolConsultaDto> Obtener();
        bool Guardar(RolRegistroDto Rol);
        bool Eliminar(long Id);
    }
}
