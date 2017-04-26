using System;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Bot.Acceso.Seguridad
{
    [Serializable]
    public class ClienteProxy : BaseProxy
    {
        public ClienteProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        public bool Guardar(ClienteDto aoClienteDto)
        {
            RespuestaApi<object> loResultado = goAgente.Ejecutar<object>("Cliente", RestSharp.Method.POST, null, new object[] { aoClienteDto });

            return loResultado.Estado ? true : false;
        }
    }
}
