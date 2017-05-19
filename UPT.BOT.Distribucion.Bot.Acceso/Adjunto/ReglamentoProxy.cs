using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Adjunto
{
    [Serializable]
    public class ReglamentoProxy : BaseProxy
    {
        public ReglamentoProxy(string rutaApi) : base(rutaApi)
        {

        }

        public List<ReglamentoDto> Obtener()
        {
            return Ejecutar<List<ReglamentoDto>>("reglamento");
        }
    }
}
