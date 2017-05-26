using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Documento
{
    public class BoletinProxy : BaseProxy
    {
        public BoletinProxy(string ruta) : base(ruta)
        {
        }

        public List<BoletinDto> Obtener() => Ejecutar<List<BoletinDto>>("boletin");
    }
}
