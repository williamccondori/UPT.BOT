using UPT.BOT.Presentacion.Web.Acceso.Gestion.Informacion;
using UPT.BOT.Presentacion.Web.Acceso.Gestion.Publicacion;
using UPT.BOT.Presentacion.Web.Administracion.Seguridad;

namespace UPT.BOT.Presentacion.Web.Administracion.Collections
{
    public class GestionCollection
    {
        public AcreditacionProxy proxyAcreditacion;
        public AdmisionProxy proxyAdmision;
        public ConvenioProxy proxyConvenio;
        public EnlaceProxy proxyEnlace;
        public NosotrosProxy proxyNosotros;

        public NoticiaProxy proxyNoticia;
        public ActualidadProxy proxyActualidad;
        public EventoProxy proxyEvento;

        public GestionCollection(string ruta)
        {
            string usuario = Sesion.Usuario();

            proxyAcreditacion = new AcreditacionProxy(ruta, usuario);
            proxyAdmision = new AdmisionProxy(ruta, usuario);
            proxyConvenio = new ConvenioProxy(ruta, usuario);
            proxyEnlace = new EnlaceProxy(ruta, usuario);
            proxyNosotros = new NosotrosProxy(ruta, usuario);

            proxyNoticia = new NoticiaProxy(ruta, usuario);
            proxyActualidad = new ActualidadProxy(ruta, usuario);
            proxyEvento = new EventoProxy(ruta, usuario);
        }
    }
}