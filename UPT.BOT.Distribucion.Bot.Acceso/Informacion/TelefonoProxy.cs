using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Informacion
{
    public class TelefonoProxy : BaseProxy
    {
        public TelefonoProxy(string ruta) : base(ruta)
        {
        }

        public List<TelefonoDto> Obtener() => Ejecutar<List<TelefonoDto>>("telefono");
    }
}
