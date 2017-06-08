using UPT.BOT.Presentacion.Web.Acceso.Gestion.Documento;
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

        public ActualidadProxy proxyActualidad;
        public EventoProxy proxyEvento;
        public ComunicadoProxy proxyComunicado;
        public PublicacionProxy proxyPublicacion;
        public GaleriaProxy proxyGaleria;

        public FormatoProxy proxyFormato;
        public BoletinProxy proxyBoletin;
        public ReglamentoProxy proxyReglamento;
        public RequisitoProxy proxyRequisito;

        public GestionCollection(string ruta)
        {
            string usuario = Sesion.Usuario();

            proxyAcreditacion = new AcreditacionProxy(ruta, usuario);
            proxyAdmision = new AdmisionProxy(ruta, usuario);
            proxyConvenio = new ConvenioProxy(ruta, usuario);
            proxyEnlace = new EnlaceProxy(ruta, usuario);
            proxyNosotros = new NosotrosProxy(ruta, usuario);

            proxyActualidad = new ActualidadProxy(ruta, usuario);
            proxyEvento = new EventoProxy(ruta, usuario);
            proxyComunicado = new ComunicadoProxy(ruta, usuario);
            proxyPublicacion = new PublicacionProxy(ruta, usuario);
            proxyGaleria = new GaleriaProxy(ruta, usuario);

            proxyFormato = new FormatoProxy(ruta, usuario);
            proxyBoletin = new BoletinProxy(ruta, usuario);
            proxyReglamento = new ReglamentoProxy(ruta, usuario);
            proxyRequisito = new RequisitoProxy(ruta, usuario);
        }
    }
}