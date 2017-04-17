using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class PublicacionConfiguration : BaseConfiguration<PublicacionEntity>
    {
        public PublicacionConfiguration()
        {
            ToTable("BOT_PUBLICACION");
            HasKey(m => new { m.CodigoPublicacion });

            Property(m => m.CodigoPublicacion).HasColumnName("COD_PUBLICACION");
            Property(m => m.CodigoTipoPublicacion).HasColumnName("COD_TIPO_PUBLICACION");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionResumen).HasColumnName("DES_RESUMEN");
            Property(m => m.DescripcionContenido).HasColumnName("DES_CONTENIDO");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
        }
    }
}
