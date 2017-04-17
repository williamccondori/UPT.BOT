using System;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Bot.Acceso.Seguridad
{
    [Serializable]
    public class ActividadProxy : BaseProxy
    {
        public ActividadProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        public bool Registrar(ActividadDto aoActividadDto)
        {
            RespuestaApi<object> loResultado = goAgente.Ejecutar<object>("Actividad", RestSharp.Method.POST, null, new object[] { aoActividadDto });

            return loResultado.Estado ? true : false;
        }
    }
}
