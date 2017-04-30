using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad;
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

        protected async Task EmpezarDialogo(Action aoFuncion)
        {
            await Task.Run(aoFuncion);
        }

        protected void EmpezarConversacion(
            IDialogContext aoContexto
            , AIResponse aoResultado
            , string asIntencion
            , IDialog<object> aoDialogo
            , ResumeAfter<object> aoContinuacion)
        {
            GuardarMensaje(aoContexto, aoResultado, asIntencion);

            aoContexto.Call(aoDialogo, aoContinuacion);
        }

        private bool GuardarMensaje(IDialogContext aoContexto, AIResponse aoResultado, string asIntencion)
        {
            MensajeDto loMensajeDto = aoContexto.UserData.Get<MensajeDto>("Mensaje");

            if (loMensajeDto != null)
            {
                loMensajeDto.DescripcionIntencion = aoResultado.Result.Metadata.IntentName;
                loMensajeDto.PorcentajeIntencion = Convert.ToDecimal(aoResultado.Result.Score);
            }

            MensajeProxy loMensajeProxy = new MensajeProxy(
             VariableConfiguracion.RutaApi(),
             VariableConfiguracion.VersionApi(),
             VariableConfiguracion.ServicioApi());

            loMensajeProxy.Registrar(loMensajeDto);

            return true;
        }
    }
}