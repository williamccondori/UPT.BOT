using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Adjunto
{
    [Serializable]
    public class BoletinProxy : BaseProxy
    {
        public BoletinProxy(string rutaApi) : base(rutaApi)
        {

        }

        public List<BoletinDto> Obtener()
        {
            return Ejecutar<List<BoletinDto>>("boletin");
        }
    }
}
