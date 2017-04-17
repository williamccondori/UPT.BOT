using System;
using UPT.BOT.Distribucion.Bot.Acceso.Utilidades;

namespace UPT.BOT.Distribucion.Bot.Acceso
{
    [Serializable]
    public class BaseProxy
    {
        protected AgenteApi goAgente;

        private readonly string Ruta;
        private readonly string Version;
        private readonly string Servicio;

        public BaseProxy(string asRuta, string asVersion, string asServicio)
        {
            this.Ruta = asRuta;
            this.Version = asVersion;
            this.Servicio = asServicio;

            goAgente = new AgenteApi(asRuta, asVersion, asServicio);
        }
    }
}
