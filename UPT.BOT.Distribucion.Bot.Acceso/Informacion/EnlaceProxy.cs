using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Informacion
{
    public class EnlaceProxy : BaseProxy
    {
        public EnlaceProxy(string ruta) : base(ruta)
        {
        }

        public List<EnlaceImportanteDto> Obtener() => Ejecutar<List<EnlaceImportanteDto>>("enlace");
    }
}
