using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Distribucion.Bot.Acceso.Seguridad;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Ai;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Dialogs;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Intents.Api
{
    [AiModel("dc1b1e61c32e42ceb143b11114e816c0")]
    [Serializable]
    public class BaseAi : AiDialog<object>
    {
        protected async Task Empezar(IDialogContext context, IAwaitable<object> aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                context.Call(new EmpezarDialog(), Terminar);
            });
        }

        protected async Task Terminar(IDialogContext aoContexto, IAwaitable<object> aoResultado)
        {
            await Task.Run(() =>
            {
                aoContexto.Done(this);
            });
        }

        protected async Task EmpezarDialogo(Action funcion)
        {
            await Task.Run(funcion);
        }

        protected void EmpezarConversacion(
            IDialogContext aoContexto
            , AIResponse aoResultado
            , IDialog<object> aoDialogo
            , ResumeAfter<object> aoContinuacion)
        {
            GuardarMensaje(aoContexto, aoResultado);
            aoContexto.Call(aoDialogo, aoContinuacion);
        }

        private bool GuardarMensaje(IDialogContext contexto, AIResponse resultado)
        {
            try
            {
                MensajeDto mensaje = contexto.UserData.GetValue<MensajeDto>("Mensaje");

                if (mensaje != null)
                {
                    mensaje.DescripcionIntencion = resultado.Result.Metadata.IntentName;
                    mensaje.PorcentajeIntencion = Convert.ToDecimal(resultado.Result.Score);

                    MensajeProxy proxyMensaje = new MensajeProxy(VariableConfiguracion.RutaApi());
                    proxyMensaje.Guardar(mensaje);
                }
            }
            catch (Exception)
            {
                contexto.SayAsync("Vas muy rápido 😓");
            }
            return true;
        }
    }
}