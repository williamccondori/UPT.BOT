using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion
{
    public interface IRedSocialService
    {
        List<RedSocialDto> Obtener();
    }
}