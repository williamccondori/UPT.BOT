using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Documento
{
    public class RequisitoProxy : BaseProxy
    {
        public RequisitoProxy(string ruta) : base(ruta)
        {
        }

        public List<RequisitoDto> Obtener() => Ejecutar<List<RequisitoDto>>("requisito");
    }
}
