using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos
{
    public class BaseDialog
    {
        protected readonly string ruta;

        public BaseDialog()
        {
            ruta = VariableConfiguracion.RutaApi();
        }
    }
}