using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class BuzonConfiguration : BaseConfiguration<BuzonEntity>
    {
        public BuzonConfiguration()
        {
            ToTable("BOT_BUZON");
            HasKey(m => new { m.CodigoBuzon });
            Property(m => m.CodigoBuzon).HasColumnName("COD_BUZON");
            Property(m => m.CodigoTipoBuzon).HasColumnName("COD_TIPO_BUZON");
            Property(m => m.CodigoCliente).HasColumnName("COD_CLIENTE");
            Property(m => m.DescripcionMensaje).HasColumnName("DES_MENSAJE");
            Property(m => m.IndicadorLeido).HasColumnName("IND_LEIDO");
            Property(m => m.IndicadorGuardado).HasColumnName("IND_GUARDADO");
            Property(m => m.IndicadorHistorial).HasColumnName("IND_HISTORIAL");
        }
    }
}
