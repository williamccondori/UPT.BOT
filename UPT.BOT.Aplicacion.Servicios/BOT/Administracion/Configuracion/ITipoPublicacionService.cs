using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion
{
    public interface ITipoPublicacionService
    {
        IList<TipoPublicacionConsultaDto> Consultar();
        bool Agregar(TipoPublicacionRegistroDto TipoPublicacion);
        bool Modificar(TipoPublicacionRegistroDto TipoPublicacion);
        bool Eliminar(long Id);
    }
}
