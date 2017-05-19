using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Seguridad
{
    public class MensajeProxy : BaseProxy
    {
        public MensajeProxy(string rutaApi) : base(rutaApi)
        {

        }

        public bool Guardar(MensajeDto mensaje)
        {
            return Ejecutar<bool>("mensaje", Metodo.Post, mensaje);
        }
    }
}
