using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Ai;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Scorables;
using static UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Dialogs.AiIntentAttribute;

namespace UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Dialogs
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    [Serializable]
    public class AiIntentAttribute : AttributeString
    {
        public readonly string intencion;

        public AiIntentAttribute(string intencion)
        {
            this.intencion = intencion;
        }

        protected override string Text => intencion;

        public delegate Task AiIntencion(IDialogContext context, AIResponse response);

        public delegate Task AiMetodoIntencion(IDialogContext context, IAwaitable<IMessageActivity> result, AIResponse response);
    }

    [Serializable]
    public class AiDialog<TResult> : IDialog<TResult>
    {
        protected readonly IAiService goServicio;

        [NonSerialized]
        protected Dictionary<string, AiMetodoIntencion> goMetodosIntencion;

        public IAiService BuscarServicio()
        {
            var type = this.GetType();

            var listaAtributos = type.GetCustomAttributes(true);

            return new AiService((IAiModel)listaAtributos[1]);
        }

        public AiDialog()
        {
            goServicio = BuscarServicio();
        }

        public virtual async Task StartAsync(IDialogContext context)
        {
            await Task.Run(() =>
            {
                context.Wait(MessageReceivedAsync);
            });
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            IMessageActivity message = await argument;

            string loMensajeContenido = message.Text;

            AIResponse loResultado = goServicio.BuscarIntencion(loMensajeContenido);

            await ReconocerMetodo(context, argument, loResultado);
        }

        protected virtual IDictionary<string, AiMetodoIntencion> GetHandlersByIntent()
        {
            IEnumerable<KeyValuePair<string, AiMetodoIntencion>> loListaIntencionesConMetodos = AiDialog.ObtenerIntencionoesConMetodos(this);

            return loListaIntencionesConMetodos.ToDictionary(p => p.Key, p => p.Value);
        }

        protected virtual async Task ReconocerMetodo(IDialogContext aoContexto, IAwaitable<IMessageActivity> aoMensaje, AIResponse aoRespuesta)
        {
            if (this.goMetodosIntencion == null)
            {
                this.goMetodosIntencion = new Dictionary<string, AiMetodoIntencion>(GetHandlersByIntent());
            }

            AiMetodoIntencion loMetodoSeleccionado = null;

            if (aoRespuesta == null || !this.goMetodosIntencion.TryGetValue(aoRespuesta.Result.Metadata.IntentName, out loMetodoSeleccionado))
            {
                loMetodoSeleccionado = this.goMetodosIntencion[string.Empty];
            }

            if (loMetodoSeleccionado != null)
            {
                await loMetodoSeleccionado(aoContexto, aoMensaje, aoRespuesta);
            }
            else
            {
                aoContexto.Done(this);
            }
        }
    }

    internal static class AiDialog
    {
        public static IEnumerable<KeyValuePair<string, AiMetodoIntencion>> ObtenerIntencionoesConMetodos(object aoClaseDialogo)
        {
            /// Se obtiene los datos de la clase dialogo.

            Type loDialogo = aoClaseDialogo.GetType();

            /// Se obtiene la lista de métodos de la clase dialogo.

            MethodInfo[] listaMetodos = loDialogo.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            /// Se recorre las lista de métodos de la clase dialogo.

            foreach (var loMetodo in listaMetodos)
            {
                /// Se obtiene la lista de atributos de la clase dialogo.

                List<AiIntentAttribute> listaAtributos = loMetodo.GetCustomAttributes<AiIntentAttribute>(inherit: true).ToList();

                AiMetodoIntencion loMetodoIntencion = null;

                if (loMetodoIntencion == null)
                {
                    try
                    {
                        AiIntencion loEntrenador = (AiIntencion)Delegate.CreateDelegate(typeof(AiIntencion), aoClaseDialogo, loMetodo, throwOnBindFailure: false);

                        if (loEntrenador != null)
                        {
                            loMetodoIntencion = (context, message, result) => loEntrenador(context, result);
                        }
                    }
                    catch (ArgumentException)
                    {

                    }
                }


                if (loMetodoIntencion == null)
                {
                    if (listaMetodos.Length > 0)
                    {

                    }
                }
                else
                {
                    IEnumerable<string> listaIntenciones = listaAtributos.Select(i => i.intencion).DefaultIfEmpty(loMetodo.Name);

                    foreach (var loIntencion in listaIntenciones)
                    {
                        string lsLlave = string.IsNullOrWhiteSpace(loIntencion) ? string.Empty : loIntencion;

                        yield return new KeyValuePair<string, AiMetodoIntencion>(lsLlave, loMetodoIntencion);
                    }
                }
            }
        }
    }
}