using ApiAiSDK.Model;
using System;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos
{
    [Serializable]
    public class BaseDialog
    {
        /// <summary>
        /// ruta del servicio de contenidos
        /// </summary>
        protected readonly string ruta;

        /// <summary>
        /// constructor
        /// </summary>
        public BaseDialog()
        {
            ruta = VariableConfiguracion.RutaApi();
        }

        /// <summary>
        /// obtiene el mensaje del servicio de intenciones
        /// </summary>
        /// <param name="respuesta">modelo de respuesta</param>
        /// <returns>respuesta establecida</returns>
        protected string ObtenerMensajeServicio(AIResponse respuesta)
        {
            if (respuesta.Result == null) return string.Empty;
            return respuesta.Result.Fulfillment.Speech;
        }
    }
}