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

        public DbSet<TipoPublicacionEntity> TipoPublicacion { get; set; }
        public DbSet<PublicacionEntity> Publicacion { get; set; }
        public DbSet<ActividadEntity> Actividad { get; set; }
        public DbSet<ActividadCuentaEntity> ActividadCuenta { get; set; }

        protected override void OnModelCreating(DbModelBuilder aoModelbuilder)
        {
            aoModelbuilder.Configurations.Add(new TipoPublicacionConfiguration());
            aoModelbuilder.Configurations.Add(new PublicacionConfiguration());
            aoModelbuilder.Configurations.Add(new ActividadConfiguration());
            aoModelbuilder.Configurations.Add(new ActividadCuentaConfiguration());

            base.OnModelCreating(aoModelbuilder);
        }

        public void GuardarCambios()
        {
            base.AplicarCambios();
        }
    }
}
