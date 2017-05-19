using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class TipoPublicacionConfiguration : BaseConfiguration<TipoPublicacionEntity>
    {
        public TipoPublicacionConfiguration()
        {
            ToTable("BOT_TIPO_PUBLICACION");
            HasKey(m => new { m.CodigoTipoPublicacion });
            Property(m => m.CodigoTipoPublicacion).HasColumnName("COD_TIPO_PUBLICACION");
            Property(m => m.DescripcionTipoPublicacion).HasColumnName("DES_TIPO_PUBLICACION");
        }
    }
}
