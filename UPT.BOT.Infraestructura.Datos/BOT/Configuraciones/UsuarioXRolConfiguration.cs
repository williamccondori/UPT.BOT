using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class UsuarioXRolConfiguration : BaseConfiguration<UsuarioXRolEntity>
    {
        public UsuarioXRolConfiguration()
        {
            ToTable("BOT_USUARIO_X_ROL");
            HasKey(m => new { m.CodigoUsuarioXRol });
            Property(m => m.CodigoUsuarioXRol).HasColumnName("COD_USUARIO_X_ROL");
            Property(m => m.CodigoUsuario).HasColumnName("COD_USUARIO");
            Property(m => m.CodigoRol).HasColumnName("COD_ROL");
            Property(m => m.IndicadorEstado).HasColumnName("IND_ESTADO");
        }
    }
}
