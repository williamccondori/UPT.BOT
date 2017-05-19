using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class EnlaceConfiguration : BaseConfiguration<EnlaceEntity>
    {
        public EnlaceConfiguration()
        {
            ToTable("BOT_ENLACE");
            HasKey(m => new { m.CodigoEnlace });
            Property(m => m.CodigoEnlace).HasColumnName("COD_ENLACE");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
        }
    }
}
