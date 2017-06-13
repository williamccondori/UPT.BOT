using System;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos
{
    [Serializable]
    public class BaseDialog
    {
        protected readonly string ruta;

        public BaseDialog()
        {
            ruta = VariableConfiguracion.RutaApi();
        }
    }
}