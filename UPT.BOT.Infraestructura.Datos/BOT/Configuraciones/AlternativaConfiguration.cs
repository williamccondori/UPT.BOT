using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class AlternativaConfiguration : BaseConfiguration<AlternativaEntity>
    {
        public AlternativaConfiguration()
        {
            ToTable("BOT_ALTERNATIVA");
            HasKey(m => new { m.CodigoAlternativa });
            Property(m => m.CodigoAlternativa).HasColumnName("COD_ALTERNATIVA");
            Property(m => m.CodigoPregunta).HasColumnName("COD_PREGUNTA");
            Property(m => m.DescripcionAlternativa).HasColumnName("DES_ALTERNATIVA");
            Property(m => m.IndicadorHabilitado).HasColumnName("IND_HABILITADO");
        }
    }
}
