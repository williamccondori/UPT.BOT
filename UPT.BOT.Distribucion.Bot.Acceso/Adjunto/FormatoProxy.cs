using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Adjunto
{
    [Serializable]
    public class FormatoProxy : BaseProxy
    {
        public FormatoProxy(string rutaApi) : base(rutaApi)
        {

        }

        public List<FormatoDto> Obtener()
        {
            return Ejecutar<List<FormatoDto>>("formato");
        }
    }
}
