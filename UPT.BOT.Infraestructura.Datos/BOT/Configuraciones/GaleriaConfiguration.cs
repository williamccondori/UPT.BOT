using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class GaleriaConfiguration : BaseConfiguration<GaleriaEntity>
    {
        public GaleriaConfiguration()
        {
            ToTable("BOT_GALERIA");
            HasKey(m => new { m.CodigoGaleria });
            Property(m => m.CodigoGaleria).HasColumnName("COD_GALERIA");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");

            HasMany(m => m.DetalleGaleriaS).WithRequired().HasForeignKey(p => p.CodigoGaleria);
        }
    }
}
