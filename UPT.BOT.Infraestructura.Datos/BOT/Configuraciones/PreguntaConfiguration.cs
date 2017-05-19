using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class PreguntaConfiguration : BaseConfiguration<PreguntaEntity>
    {
        public PreguntaConfiguration()
        {
            ToTable("BOT_PREGUNTA");
            HasKey(m => new { m.CodigoPregunta });
            Property(m => m.CodigoPregunta).HasColumnName("COD_PREGUNTA");
            Property(m => m.CodigoEncuesta).HasColumnName("COD_ENCUESTA");
            Property(m => m.DescripcionPregunta).HasColumnName("DES_PREGUNTA");
            Property(m => m.IndicadorHabilitado).HasColumnName("IND_HABILITADO");
        }
    }
}
