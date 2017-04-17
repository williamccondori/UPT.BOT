using System.Data.Entity.ModelConfiguration;
using UPT.BOT.Dominio.Entidades;

namespace UPT.BOT.Infraestructura.Datos.BOT.Shared
{
    public class BaseConfiguration<TEntidad> : EntityTypeConfiguration<TEntidad> where TEntidad : class, IBaseEntity
    {
        public BaseConfiguration()
        {
            Property(p => p.IndicadorEstado).HasColumnName("IND_ESTADO");
            Property(p => p.UsuarioRegistro).HasColumnName("USU_REGISTRO");
            Property(p => p.UsuarioModifico).HasColumnName("USU_MODIFICO");
            Property(p => p.FechaRegistro).HasColumnName("FEC_REGISTRO");
            Property(p => p.FechaModifico).HasColumnName("FEC_MODIFICO");
            Ignore(p => p.EstadoObjeto);
        }
    }
}
