using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class RolConfiguration : BaseConfiguration<RolEntity>
    {
        public RolConfiguration()
        {
            ToTable("BOT_ROL");
            HasKey(m => new { m.CodigoRol });

            Property(m => m.CodigoRol).HasColumnName("COD_ROL");
            Property(m => m.DescripcionRol).HasColumnName("DES_ROL");
        }
    }
}
