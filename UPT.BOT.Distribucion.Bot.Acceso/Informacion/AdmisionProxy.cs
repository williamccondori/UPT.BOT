using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Informacion
{
    public class AdmisionProxy : BaseProxy
    {
        public AdmisionProxy(string ruta) : base(ruta)
        {
        }

        public List<AdmisionDto> Obtener() => Ejecutar<List<AdmisionDto>>("admision");
    }
}
