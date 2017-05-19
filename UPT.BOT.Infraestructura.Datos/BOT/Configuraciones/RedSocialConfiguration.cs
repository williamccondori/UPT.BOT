using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class RedSocialConfiguration : BaseConfiguration<RedSocialEntity>
    {
        public RedSocialConfiguration()
        {
            ToTable("BOT_RED_SOCIAL");
            HasKey(m => new { m.CodigoRedSocial });
            Property(m => m.CodigoRedSocial).HasColumnName("COD_RED_SOCIAL");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
        }
    }
}
