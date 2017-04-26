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

        }

        /*
         * módulo de seguridad.
         * */

        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<RolEntity> Rol { get; set; }
        public DbSet<ObjetoEntity> Objeto { get; set; }
        public DbSet<UsuarioXRolEntity> UsuarioXRol { get; set; }
        public DbSet<ObjetoXRolEntity> ObjetoXRol { get; set; }

        /*
         * módulo de publicaciones.
         * */

        public DbSet<TipoPublicacionEntity> TipoPublicacion { get; set; }
        public DbSet<PublicacionEntity> Publicacion { get; set; }

        public DbSet<MensajeEntity> Mensaje { get; set; }
        public DbSet<ClienteEntity> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder aoModelbuilder)
        {
            aoModelbuilder.Configurations.Add(new TipoPublicacionConfiguration());
            aoModelbuilder.Configurations.Add(new PublicacionConfiguration());
            aoModelbuilder.Configurations.Add(new MensajeConfiguration());
            aoModelbuilder.Configurations.Add(new ClienteConfiguration());

            aoModelbuilder.Configurations.Add(new RolConfiguration());
            aoModelbuilder.Configurations.Add(new ObjetoConfiguration());
            aoModelbuilder.Configurations.Add(new UsuarioConfiguration());
            aoModelbuilder.Configurations.Add(new UsuarioXRolConfiguration());
            aoModelbuilder.Configurations.Add(new ObjetoXRolConfiguration());

            base.OnModelCreating(aoModelbuilder);
        }

        public void GuardarCambios()
        {
            base.AplicarCambios();
        }
    }
}
