using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class AdjuntoConfiguration : BaseConfiguration<AdjuntoEntity>
    {
        public AdjuntoConfiguration()
        {
            ToTable("BOT_ADJUNTO");
            HasKey(m => new { m.CodigoAdjunto });
            Property(m => m.CodigoAdjunto).HasColumnName("COD_ADJUNTO");
            Property(m => m.CodigoTipoAdjunto).HasColumnName("COD_TIPO_ADJUNTO");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionSubtitulo).HasColumnName("DES_SUBTITULO");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionResumen).HasColumnName("DES_RESUMEN");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
        }
    }
}