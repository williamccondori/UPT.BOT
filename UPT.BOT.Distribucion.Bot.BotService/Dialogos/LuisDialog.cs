using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Threading.Tasks;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Adjunto;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Bot;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos
{
    [Serializable]
    public class LuisDialog : BaseLuisDialog
    {
        public LuisDialog()
        {

        }

        [LuisIntent(Intencion.Predeterminado)]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await EmpezarDialogo(() =>
            {
                context.Call(new PredeterminadoDialog(), Empezar);
            });
        }

        [LuisIntent("Noticia")]
        public async Task Noticia(IDialogContext context, LuisResult result)
        {
            await EmpezarDialogo(() =>
            {
                context.Call(new NoticiaDialog(), TerminarConversacion);
            });
        }

        [LuisIntent("MallaCurricular")]
        public async Task MallaCurricular(IDialogContext context, LuisResult result)
        {
            await EmpezarDialogo(() =>
            {
                context.Call(new MallaCurricularDialog(), TerminarConversacion);
            });
        }

        [LuisIntent("Reglamento")]
        public async Task Reglamento(IDialogContext context, LuisResult result)
        {
            await EmpezarDialogo(() =>
            {
                context.Call(new ReglamentoDialog(), TerminarConversacion);
            });
        }

        [LuisIntent(Intencion.Agradecer)]
        public async Task Agradecer(IDialogContext context, LuisResult result)
        {
            await EmpezarDialogo(() =>
            {
                context.Call(new PredeterminadoDialog(), TerminarConversacion);
            });
        }

        [LuisIntent(Intencion.Saludar)]
        public async Task Saludar(IDialogContext context, LuisResult result)
        {
            await EmpezarDialogo(() =>
            {
                context.Call(new SaludarDialog(), Empezar);
            });
        }

        private Task Empezar(IDialogContext context, IAwaitable<object> result)
        {
            return EmpezarDialogo(() =>
            {
                context.Call(new EmpezarDialog(), TerminarConversacion);
            });
        }
    }
}