using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class TipoBuzonConfiguration : BaseConfiguration<TipoBuzonEntity>
    {
        public TipoBuzonConfiguration()
        {
            ToTable("BOT_TIPO_BUZON");
            HasKey(m => new { m.CodigoTipoBuzon });
            Property(m => m.CodigoTipoBuzon).HasColumnName("COD_TIPO_BUZON");
            Property(m => m.DescripcionTipoBuzon).HasColumnName("DES_TIPO_BUZON");
        }
    }
}
