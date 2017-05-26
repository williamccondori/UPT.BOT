using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Informacion
{
    public class SocialProxy : BaseProxy
    {
        public SocialProxy(string ruta) : base(ruta)
        {
        }

        public List<SocialDto> Obtener() => Ejecutar<List<SocialDto>>("social");
    }
}
