using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class EncuestaConfiguration : BaseConfiguration<EncuestaEntity>
    {
        public EncuestaConfiguration()
        {
            ToTable("BOT_ENCUESTA");
            HasKey(m => new { m.CodigoEncuesta });
            Property(m => m.CodigoEncuesta).HasColumnName("COD_ENCUESTA");
            Property(m => m.DescripcionEncuesta).HasColumnName("DES_ENCUESTA");
            Property(m => m.IndicadorHabilitado).HasColumnName("IND_HABILITADO");
            Property(m => m.FechaInicio).HasColumnName("FEC_INICIO");
            Property(m => m.FechaFin).HasColumnName("FEC_FIN");
        }
    }
}
