using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class TelefonoConfiguration : BaseConfiguration<TelefonoEntity>
    {
        public TelefonoConfiguration()
        {
            ToTable("BOT_TELEFONO");
            HasKey(m => new { m.CodigoTelefono });
            Property(m => m.CodigoTelefono).HasColumnName("COD_TELEFONO");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionTelefono).HasColumnName("DES_TELEFONO");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
        }
    }
}
