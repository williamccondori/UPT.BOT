using System;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Bot.Acceso.Seguridad
{
    [Serializable]
    public class MensajeProxy : BaseProxy
    {
        public MensajeProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        public bool Registrar(MensajeDto aoMensajeDto)
        {
            RespuestaApi<object> loResultado = goAgente.Ejecutar<object>("Mensaje", RestSharp.Method.POST, null, new object[] { aoMensajeDto });

            return loResultado.Estado ? true : false;
        }
    }
}
