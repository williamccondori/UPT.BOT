using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos
{
    [LuisModel("c95eea17-8fa0-4a58-99f4-8bbf7a326712", "ae9f24eb822140c4b573f6c8da0a9fed")]
    [Serializable]
    public class BaseLuisDialog : LuisDialog<object>
    {
        protected async Task TerminarConversacion(IDialogContext aoContexto, IAwaitable<object> soResultado)
        {
            await Task.CompletedTask;
            aoContexto.Done(this);
        }

        protected bool ValidarIntencion(LuisResult aoResultado, string asIntencion)
        {
            bool lbIntencion = false;

            foreach (var loIntencion in aoResultado.Intents)
            {
                if (loIntencion.Intent == asIntencion && loIntencion.Score >= .70F)
                {
                    lbIntencion = true;
                }
            }

            return lbIntencion;
        }

        protected async Task EmpezarDialogo(System.Action aoFuncion)
        {
            aoFuncion();
            await Task.FromResult(0);
        }
    }
}