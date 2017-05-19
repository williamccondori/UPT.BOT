using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class DireccionConfiguration : BaseConfiguration<DireccionEntity>
    {
        public DireccionConfiguration()
        {
            ToTable("BOT_DIRECCION");
            HasKey(m => new { m.CodigoDireccion });
            Property(m => m.CodigoDireccion).HasColumnName("COD_DIRECCION");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionDireccion).HasColumnName("DES_DIRECCION");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
            Property(m => m.DescripcionMapa).HasColumnName("DES_MAPA");
        }
    }
}
