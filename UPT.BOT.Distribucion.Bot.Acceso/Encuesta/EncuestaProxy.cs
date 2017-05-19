using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Encuesta
{
    [Serializable]
    public class EncuestaProxy : BaseProxy
    {
        public EncuestaProxy(string rutaApi) : base(rutaApi)
        {

        }

        public List<EncuestaDto> Obtener()
        {
            return Ejecutar<List<EncuestaDto>>("encuesta");
        }
    }
}
