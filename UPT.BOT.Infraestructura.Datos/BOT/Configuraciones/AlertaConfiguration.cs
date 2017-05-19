using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class AlertaConfiguration : BaseConfiguration<AlertaEntity>
    {
        public AlertaConfiguration()
        {
            ToTable("BOT_ALERTA");
            HasKey(m => new { m.CodigoAlerta });
            Property(m => m.CodigoAlerta).HasColumnName("COD_ALERTA");
            Property(m => m.DescripcionAlerta).HasColumnName("DES_ALERTA");
            Property(m => m.DescripcionMensaje).HasColumnName("DES_MENSAJE");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.FechaAlerta).HasColumnName("FEC_ALERTA");
        }
    }
}
