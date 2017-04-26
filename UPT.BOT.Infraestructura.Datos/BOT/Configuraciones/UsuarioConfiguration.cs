using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class UsuarioConfiguration : BaseConfiguration<UsuarioEntity>
    {
        public UsuarioConfiguration()
        {
            ToTable("BOT_USUARIO");
            HasKey(m => new { m.CodigoUsuario });

            Property(m => m.CodigoUsuario).HasColumnName("COD_USUARIO");
            Property(m => m.DescripcionNombre).HasColumnName("DES_NOMBRE");
            Property(m => m.DescripcionApellido).HasColumnName("DES_APELLIDO");
            Property(m => m.DescripcionEmail).HasColumnName("DES_EMAIL");
            Property(m => m.DescripcionUsuario).HasColumnName("DES_USUARIO");
            Property(m => m.DescripcionPassword).HasColumnName("DES_PASSWORD");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.IndicadorHabilitado).HasColumnName("IND_HABILITADO");
        }
    }
}
