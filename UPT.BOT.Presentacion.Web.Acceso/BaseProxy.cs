using UPT.BOT.Presentacion.Web.Administracion.Utilidades;

namespace UPT.BOT.Presentacion.Web.Acceso
{
    public class BaseProxy
    {
        protected AgenteApi agenteApi;

        private readonly string Ruta;
        private readonly string Version;
        private readonly string Servicio;

        public BaseProxy(string asRuta, string asVersion, string asServicio)
        {
            this.Ruta = asRuta;
            this.Version = asVersion;
            this.Servicio = asServicio;

            agenteApi = new AgenteApi(asRuta, asVersion, asServicio);
        }
    }
}
