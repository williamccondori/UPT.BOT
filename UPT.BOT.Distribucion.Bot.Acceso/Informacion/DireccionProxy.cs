using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Informacion
{
    public class DireccionProxy : BaseProxy
    {
        public DireccionProxy(string ruta) : base(ruta)
        {
        }

        public List<DireccionDto> Obtener() => Ejecutar<List<DireccionDto>>("direccion");
    }
}
