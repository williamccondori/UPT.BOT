using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Publicacion
{
    [Serializable]
    public class EventoProxy : BaseProxy
    {
        public EventoProxy(string rutaApi) : base(rutaApi)
        {

        }

        public List<EventoDto> Obtener()
        {
            return Ejecutar<List<EventoDto>>("evento");
        }
    }
}
