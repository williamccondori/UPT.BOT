using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Documento
{
    public interface IReglamentoService
    {
        bool Eliminar(object id);
        bool Guardar(ReglamentoDto reglamento);
        IList<ReglamentoDto> Obtener();
    }
}
