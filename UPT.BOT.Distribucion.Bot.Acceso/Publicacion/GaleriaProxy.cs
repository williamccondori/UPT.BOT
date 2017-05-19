using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Publicacion
{
    [Serializable]
    public class GaleriaProxy : BaseProxy
    {
        public GaleriaProxy(string rutaApi) : base(rutaApi)
        {

        }

        public List<GaleriaDto> Obtener()
        {
            return Ejecutar<List<GaleriaDto>>("galeria");
        }
    }
}
