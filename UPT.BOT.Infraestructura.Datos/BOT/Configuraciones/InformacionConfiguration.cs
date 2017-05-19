using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class InformacionConfiguration : BaseConfiguration<InformacionEntity>
    {
        public InformacionConfiguration()
        {
            ToTable("BOT_INFORMACION");
            HasKey(m => new { m.CodigoInformacion });
            Property(m => m.CodigoInformacion).HasColumnName("COD_INFORMACION");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionMensaje).HasColumnName("DES_MENSAJE");
            Property(m => m.DescripcionIntencion).HasColumnName("DES_INTENCION");
        }
    }
}
