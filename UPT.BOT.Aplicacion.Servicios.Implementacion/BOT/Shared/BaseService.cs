using UPT.BOT.Infraestructura.Datos.BOT.Contextos;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared
{
    public class BaseService
    {
        protected BotContext contexto;

        public BaseService()
        {
            contexto = new BotContext();
        }
    }
}
