using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class TarjetaConfiguration : BaseConfiguration<TarjetaEntity>
    {
        public TarjetaConfiguration()
        {
            ToTable("BOT_TARJETA");
            HasKey(m => new { m.CodigoTarjeta });

            Property(m => m.CodigoTarjeta).HasColumnName("COD_TARJETA");
            Property(m => m.CodigoTipoTarjeta).HasColumnName("COD_TIPO_TARJETA");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionSubtitulo).HasColumnName("DES_SUBTITULO");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
            Property(m => m.IndicadorHabilitado).HasColumnName("IND_HABILITADO");
            HasRequired(g => g.TipoTarjetaX).WithMany().HasForeignKey(g => g.CodigoTipoTarjeta);

            Ignore(g => g.EstadoObjeto);
        }
    }
}
