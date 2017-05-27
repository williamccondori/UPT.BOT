using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Distribucion.Bot.Acceso.Seguridad;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Ai;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Dialogs;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Extras;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Intents.Api
{
    [AiModel("dc1b1e61c32e42ceb143b11114e816c0")]
    [Serializable]
    public class BaseAi : AiDialog<object>
    {
        protected async Task Empezar(Action funcion)
            => await Task.Run(funcion);

        protected async Task Terminar(IDialogContext context, IAwaitable<object> result)
            => await Task.Run(() => context.EndConversation(ActivityTypes.EndOfConversation));

        protected async Task Menu(IDialogContext context, IAwaitable<object> result)
            => await Empezar(() => context.Call(new MenuDialog(), Terminar));

        protected void Dialogo(IDialogContext context, AIResponse response, IDialog<object> dialogo, ResumeAfter<object> siguiente = null)
        {
            ResumeAfter<object> resumen = siguiente ?? Terminar;

            // se almacena el mensaje con la intención detectada por el servicio

            RegisterMessage(context, response);

            // se empieza el dialogo

            context.Call(dialogo, resumen);
        }

        private void RegisterMessage(IDialogContext context, AIResponse response)
        {
            // se recupera elobjeto mensaje creado en el controlador

            Activity actividad = (Activity)context.Activity;

            // se procede al registro del mensaje

            MensajeDto message = new MensajeDto
            {
                CodigoCliente = actividad.From.Id,
                DescripcionActividad = actividad.Id,
                DescripcionCanal = actividad.ChannelId,
                DescripcionContenido = actividad.Text,
                DescripcionIntencion = response.Result.Metadata.IntentName,
                DescripcionLocalidad = actividad.Locale,
                DescripcionServicio = actividad.ServiceUrl,
                DescripcionTipoContenido = actividad.TextFormat,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaMensaje = actividad.Timestamp,
                PorcentajeIntencion = (decimal)response.Result.Score
            };


            MensajeProxy proxyMensaje = new MensajeProxy(VariableConfiguracion.RutaApi());
            proxyMensaje.Guardar(message);
        }
    }
}