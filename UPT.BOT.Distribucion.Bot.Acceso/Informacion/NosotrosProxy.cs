using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Informacion
{
    public class NosotrosProxy : BaseProxy
    {
        public NosotrosProxy(string ruta) : base(ruta)
        {
        }

        public NosotrosDto Obtener() => Ejecutar<NosotrosDto>("nosotros");
    }
}
