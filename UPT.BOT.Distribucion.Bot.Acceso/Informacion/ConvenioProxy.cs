using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Informacion
{
    public class ConvenioProxy : BaseProxy
    {
        public ConvenioProxy(string ruta) : base(ruta)
        {
        }

        public List<ConvenioDto> Obtener() => Ejecutar<List<ConvenioDto>>("convenio");
    }
}
