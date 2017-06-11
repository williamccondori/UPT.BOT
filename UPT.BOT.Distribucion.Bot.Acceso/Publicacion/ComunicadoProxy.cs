using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Publicacion
{
    [Serializable]
    public class ComunicadoProxy : BaseProxy
    {
        public ComunicadoProxy(string ruta) : base(ruta)
        {
        }

        public List<ComunicadoDto> Obtener()
        {
            return Ejecutar<List<ComunicadoDto>>("comunicado");
        }
    }
}
