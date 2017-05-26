using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Informacion
{
    public class AcreditacionProxy : BaseProxy
    {
        public AcreditacionProxy(string ruta) : base(ruta)
        {
        }

        public List<AcreditacionDto> Obtener() => Ejecutar<List<AcreditacionDto>>("acreditacion");
    }
}
