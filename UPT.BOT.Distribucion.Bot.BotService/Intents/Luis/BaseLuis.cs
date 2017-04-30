using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad;
using UPT.BOT.Distribucion.Bot.Acceso.Seguridad;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Intents.Luis
{
    [LuisModel("c95eea17-8fa0-4a58-99f4-8bbf7a326712", "ae9f24eb822140c4b573f6c8da0a9fed")]
    [Serializable]
    public class BaseLuis : LuisDialog<object>
    {
        protected Task Empezar(IDialogContext context, IAwaitable<object> result)
        {
            return EmpezarDialogo(() =>
            {
                context.Call(new EmpezarDialog(), Terminar);
            });
        }

        protected async Task Terminar(IDialogContext aoContexto, IAwaitable<object> aoResultado)
        {
            await Task.CompletedTask;

            aoContexto.Done(this);
        }

        protected async Task EmpezarDialogo(System.Action aoFuncion)
        {
            aoFuncion();

            await Task.FromResult(0);
        }

        protected void EmpezarConversacion(
            IDialogContext aoContexto
            , LuisResult aoResultado
            , string asIntencion
            , IDialog<object> aoDialogo
            , ResumeAfter<object> aoContinuacion)
        {
            GuardarMensaje(aoContexto, aoResultado, asIntencion);

            if (ValidarMensaje(aoResultado, asIntencion))
            {
                aoContexto.Call(aoDialogo, aoContinuacion);
            }
            else
            {
                aoContexto.Call(new PredeterminadoDialog(), Empezar);
            }
        }

        private bool ValidarMensaje(LuisResult aoResultado, string asIntencion)
        {
            bool lbIntencion = false;

            foreach (var loIntencion in aoResultado.Intents)
            {
                if (loIntencion.Intent == asIntencion && loIntencion.Score >= .60F)
                {
                    lbIntencion = true;
                }
            }

            return lbIntencion;
        }

        private bool GuardarMensaje(IDialogContext aoContexto, LuisResult aoResultado, string asIntencion)
        {
            try
            {
                MensajeDto loMensajeDto = aoContexto.UserData.Get<MensajeDto>("Mensaje");

                IntentRecommendation loIntencion = aoResultado.Intents.FirstOrDefault(p => p.Intent == asIntencion);

                if (loMensajeDto != null)
                {
                    loMensajeDto.DescripcionIntencion = loIntencion.Intent;
                    loMensajeDto.PorcentajeIntencion = Convert.ToDecimal(loIntencion.Score);
                }

                MensajeProxy loMensajeProxy = new MensajeProxy(
                 VariableConfiguracion.RutaApi(),
                 VariableConfiguracion.VersionApi(),
                 VariableConfiguracion.ServicioApi());

                loMensajeProxy.Registrar(loMensajeDto);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}