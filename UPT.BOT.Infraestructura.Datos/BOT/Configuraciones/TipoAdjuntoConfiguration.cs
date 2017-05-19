using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class TipoAdjuntoConfiguration : BaseConfiguration<TipoAdjuntoEntity>
    {
        public TipoAdjuntoConfiguration()
        {
            ToTable("BOT_TIPO_ADJUNTO");
            HasKey(m => new { m.CodigoTipoAdjunto });
            Property(m => m.CodigoTipoAdjunto).HasColumnName("COD_TIPO_ADJUNTO");
            Property(m => m.DescripcionTipoAdjunto).HasColumnName("DES_TIPO_ADJUNTO");
        }
    }
}
