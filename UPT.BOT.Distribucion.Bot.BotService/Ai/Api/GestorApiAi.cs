using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using UPT.BOT.Distribucion.Bot.BotService.ApiSdk;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Bot;

namespace UPT.BOT.Distribucion.Bot.BotService.Ai.Api
{
    public class GestorApiAi : BaseApiAi
    {

        [ApiAiIntent("Noticia")]
        public async Task Noticia(IDialogContext aoContexto, ApiAiResult aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "Noticia", new NoticiaDialog(), Terminar);
            });
        }
    }
}