using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Informacion
{
    public class ServicioProxy : BaseProxy
    {
        public ServicioProxy(string ruta) : base(ruta)
        {
        }

        public List<ServicioDto> Obtener() => Ejecutar<List<ServicioDto>>("servicio");
    }
}
