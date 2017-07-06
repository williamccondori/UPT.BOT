using System.Data.Entity;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Configuraciones;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Contextos
{
    public class BotContext : BaseContext
    {
        public BotContext()
               : base("name=BOTConnection")
        {
            Database.SetInitializer<BotContext>(null);
        }
        //public DbSet<AdjuntoEntity> Adjunto { get; set; }
        //public DbSet<AdmisionEntity> Admision { get; set; }
        //public DbSet<AlertaEntity> Alerta { get; set; }
        //public DbSet<AlternativaEntity> Alternativa { get; set; }
        //public DbSet<BuzonEntity> Buzon { get; set; }
        //public DbSet<ClienteEntity> Cliente { get; set; }
        //public DbSet<DetalleGaleriaEntity> DetalleGaleria { get; set; }
        //public DbSet<DetallePlanEstudioEntity> DetallePlanEstudio { get; set; }
        //public DbSet<DireccionEntity> Direccion { get; set; }
        //public DbSet<DocumentoEntity> Documento { get; set; }
        //public DbSet<EncuestaEntity> Encuesta { get; set; }
        //public DbSet<EnlaceImportanteEntity> Enlace { get; set; }
        //public DbSet<EventoEntity> Evento { get; set; }
        //public DbSet<GaleriaEntity> Galeria { get; set; }
        //public DbSet<InformacionEntity> Informacion { get; set; }
        //public DbSet<MensajeEntity> Mensaje { get; set; }
        public DbSet<ObjetoEntity> Objeto { get; set; }
        //public DbSet<ObjetoXRolEntity> ObjetoXRol { get; set; }
        //public DbSet<PlanEstudioEntity> PlanEstudio { get; set; }
        //public DbSet<PreguntaEntity> Pregunta { get; set; }
        //public DbSet<PublicacionEntity> Publicacion { get; set; }
        //public DbSet<RedSocialEntity> RedSocial { get; set; }
        //public DbSet<RespuestaEntity> Respuesta { get; set; }
        public DbSet<RolEntity> Rol { get; set; }
        //public DbSet<TelefonoEntity> Telefono { get; set; }
        //public DbSet<TipoAdjuntoEntity> TipoAdjunto { get; set; }
        //public DbSet<TipoBuzonEntity> TipoBuzon { get; set; }
        //public DbSet<TipoDocumentoEntity> TipoDocumento { get; set; }
        //public DbSet<TipoPublicacionEntity> TipoPublicacion { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        //public DbSet<UsuarioXRolEntity> UsuarioXRol { get; set; }

        public DbSet<TipoTarjetaEntity> TipoTarjeta { get; set; }
        public DbSet<TarjetaEntity> Tarjeta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //aoModelbuilder.Configurations.Add(new AdjuntoConfiguration());
            //aoModelbuilder.Configurations.Add(new AdmisionConfiguration());
            //aoModelbuilder.Configurations.Add(new AlertaConfiguration());
            //aoModelbuilder.Configurations.Add(new AlternativaConfiguration());
            //aoModelbuilder.Configurations.Add(new BuzonConfiguration());
            //aoModelbuilder.Configurations.Add(new ClienteConfiguration());
            //aoModelbuilder.Configurations.Add(new DetalleGaleriaConfiguration());
            //aoModelbuilder.Configurations.Add(new DetallePlanEstudioConfiguration());
            //aoModelbuilder.Configurations.Add(new DireccionConfiguration());
            //aoModelbuilder.Configurations.Add(new DocumentoConfiguration());
            //aoModelbuilder.Configurations.Add(new EncuestaConfiguration());
            //aoModelbuilder.Configurations.Add(new EnlaceConfiguration());
            //aoModelbuilder.Configurations.Add(new EventoConfiguration());
            //aoModelbuilder.Configurations.Add(new GaleriaConfiguration());
            //aoModelbuilder.Configurations.Add(new InformacionConfiguration());
            //aoModelbuilder.Configurations.Add(new MensajeConfiguration());
            modelBuilder.Configurations.Add(new ObjetoConfiguration());
            //aoModelbuilder.Configurations.Add(new ObjetoXRolConfiguration());
            //aoModelbuilder.Configurations.Add(new PlanEstudioConfiguration());
            //aoModelbuilder.Configurations.Add(new PreguntaConfiguration());
            //aoModelbuilder.Configurations.Add(new PublicacionConfiguration());
            //aoModelbuilder.Configurations.Add(new RedSocialConfiguration());
            //aoModelbuilder.Configurations.Add(new RespuestaConfiguration());
            modelBuilder.Configurations.Add(new RolConfiguration());
            //aoModelbuilder.Configurations.Add(new TelefonoConfiguration());
            //aoModelbuilder.Configurations.Add(new TipoAdjuntoConfiguration());
            //aoModelbuilder.Configurations.Add(new TipoBuzonConfiguration());
            //aoModelbuilder.Configurations.Add(new TipoDocumentoConfiguration());
            //aoModelbuilder.Configurations.Add(new TipoPublicacionConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            //aoModelbuilder.Configurations.Add(new UsuarioXRolConfiguration());
            modelBuilder.Configurations.Add(new TipoTarjetaConfiguration());
            modelBuilder.Configurations.Add(new TarjetaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public void GuardarCambios()
        {
            base.AplicarCambios();
        }
    }
}
