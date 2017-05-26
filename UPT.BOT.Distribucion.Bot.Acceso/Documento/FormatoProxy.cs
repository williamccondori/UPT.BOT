using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Documento
{
    public class FormatoProxy : BaseProxy
    {
        public FormatoProxy(string ruta) : base(ruta)
        {
        }

        public List<FormatoDto> Obtener() => Ejecutar<List<FormatoDto>>("formato");
    }
}
