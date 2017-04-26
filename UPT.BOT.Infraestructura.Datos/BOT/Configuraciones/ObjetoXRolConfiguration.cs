using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class ObjetoXRolConfiguration : BaseConfiguration<ObjetoXRolEntity>
    {
        public ObjetoXRolConfiguration()
        {
            ToTable("BOT_OBJETO_X_ROL");
            HasKey(m => new { m.CodigoObjetoXRol });

            Property(m => m.CodigoObjetoXRol).HasColumnName("COD_OBJETO_X_ROL");
            Property(m => m.CodigoObjeto).HasColumnName("COD_OBJETO");
            Property(m => m.CodigoRol).HasColumnName("COD_ROL");
            Property(m => m.IndicadorHabilitado).HasColumnName("IND_HABILITADO");
        }
    }
}
