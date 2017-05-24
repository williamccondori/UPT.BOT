﻿using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Dialogs;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Documento;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Informacion;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Planestudio;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Publicacion;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared;

namespace UPT.BOT.Distribucion.Bot.BotService.Intents.Api
{
    [Serializable]
    public class GestorAi : BaseAi
    {
        [AiIntent("Predeterminado")]
        public async Task Predeterminado(IDialogContext contexto, AIResponse resultado)
            => await EmpezarDialogo(() => EmpezarConversacion(contexto, resultado, new PredeterminadoDialog(resultado.Result.Fulfillment.Speech), Terminar));


        [AiIntent("extras.saludo")]
        public async Task Saludar(IDialogContext contexto, AIResponse resultado)
            => await EmpezarDialogo(() => EmpezarConversacion(contexto, resultado, new SaludarDialog(resultado.Result.Fulfillment.Speech), Empezar));


        [AiIntent("informacion.direccion")]
        public async Task Direccion(IDialogContext contexto, AIResponse resultado)
        {
            await EmpezarDialogo(() => EmpezarConversacion(contexto, resultado, new DireccionDialog(resultado.Result.Fulfillment.Speech), Terminar));
        }

        [AiIntent("informacion.telefono")]
        public async Task Telefono(IDialogContext contexto, AIResponse resultado)
        {
            await EmpezarDialogo(() => EmpezarConversacion(contexto, resultado, new TelefonoDialog(resultado.Result.Fulfillment.Speech), Terminar));
        }

        [AiIntent("publicacion.noticia")]
        public async Task Noticia(IDialogContext contexto, AIResponse resultado)
        {
            await EmpezarDialogo(() => EmpezarConversacion(contexto, resultado, new NoticiaDialog(resultado.Result.Fulfillment.Speech), Terminar));
        }

        [AiIntent("planestudio.mallacurricular")]
        public async Task MallaCurricular(IDialogContext contexto, AIResponse resultado)
            => await EmpezarDialogo(() => EmpezarConversacion(contexto, resultado, new MallaCurricularDialog(resultado.Result.Fulfillment.Speech), Terminar));


        [AiIntent("documento.boletin")]
        public async Task Boletin(IDialogContext contexto, AIResponse resultado)
            => await EmpezarDialogo(() => EmpezarConversacion(contexto, resultado, new BoletinDialog(resultado.Result.Fulfillment.Speech), Terminar));


        [AiIntent("documento.formato")]
        public async Task Formato(IDialogContext contexto, AIResponse resultado)
            => await EmpezarDialogo(() => EmpezarConversacion(contexto, resultado, new FormatoDialog(resultado.Result.Fulfillment.Speech), Terminar));


        [AiIntent("documento.reglamento")]
        public async Task Reglamento(IDialogContext contexto, AIResponse resultado)
            => await EmpezarDialogo(() => EmpezarConversacion(contexto, resultado, new ReglamentoDialog(resultado.Result.Fulfillment.Speech), Terminar));

    }
}