using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Publicacion
{
    [Serializable]
    public class ActualidadProxy : BaseProxy
    {
        public ActualidadProxy(string rutaApi) : base(rutaApi)
        {

        }

        public List<ActualidadDto> Obtener()
        {
            return Ejecutar<List<ActualidadDto>>("actualidad");
        }
    }
}
