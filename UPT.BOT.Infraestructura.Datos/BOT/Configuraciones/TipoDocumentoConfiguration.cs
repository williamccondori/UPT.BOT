using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class TipoDocumentoConfiguration : BaseConfiguration<TipoDocumentoEntity>
    {
        public TipoDocumentoConfiguration()
        {
            ToTable("BOT_TIPO_DOCUMENTO");
            HasKey(m => new { m.CodigoTipoDocumento });
            Property(m => m.CodigoTipoDocumento).HasColumnName("COD_TIPO_DOCUMENTO");
            Property(m => m.DescripcionTipoDocumento).HasColumnName("DES_TIPO_DOCUMENTO");
        }
    }
}
