using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Documento
{
    public class ReglamentoProxy : BaseProxy
    {
        public ReglamentoProxy(string ruta) : base(ruta)
        {
        }

        public List<ReglamentoDto> Obtener() => Ejecutar<List<ReglamentoDto>>("reglamento");
    }
}
