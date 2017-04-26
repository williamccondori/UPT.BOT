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
    public class GestorLuis : BaseLuis
    {
        public GestorLuis()
        {

        }

        [LuisIntent(Intencion.Predeterminado)]
        public async Task None(IDialogContext aoContexto, LuisResult aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "None", new PredeterminadoDialog(), Empezar);
            });
        }

        public async Task Noticia(IDialogContext aoContexto, LuisResult aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "Noticia", new NoticiaDialog(), Terminar);
            });
        }

        [LuisIntent("MallaCurricular")]
        public async Task MallaCurricular(IDialogContext aoContexto, LuisResult aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "MallaCurricular", new MallaCurricularDialog(), Terminar);
            });
        }

        [LuisIntent("Reglamento")]
        public async Task Reglamento(IDialogContext aoContexto, LuisResult aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "Reglamento", new ReglamentoDialog(), Terminar);
            });
        }

        [LuisIntent(Intencion.Agradecer)]
        public async Task Agradecer(IDialogContext aoContexto, LuisResult aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, Intencion.Agradecer, new PredeterminadoDialog(), Terminar);
            });
        }

        [LuisIntent(Intencion.Saludar)]
        public async Task Saludar(IDialogContext aoContexto, LuisResult aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, Intencion.Saludar, new SaludarDialog(), Empezar);
            });
        }
    }
}