using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class AdmisionConfiguration : BaseConfiguration<AdmisionEntity>
    {
        public AdmisionConfiguration()
        {
            ToTable("BOT_ADMISION");
            HasKey(m => new { m.CodigoAdmision });
            Property(m => m.CodigoAdmision).HasColumnName("COD_ADMISION");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
            Property(m => m.IndicadorConcluido).HasColumnName("IND_CONCLUIDO");
        }
    }
}
