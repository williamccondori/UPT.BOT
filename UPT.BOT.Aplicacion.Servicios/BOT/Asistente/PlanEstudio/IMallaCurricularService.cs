using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.PlanEstudio
{
    public interface IMallaCurricularService
    {
        List<MallaCurricularDto> Obtener();
    }
}
