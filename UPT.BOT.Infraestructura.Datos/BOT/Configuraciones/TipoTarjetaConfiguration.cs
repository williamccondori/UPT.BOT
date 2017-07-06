using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class TipoTarjetaConfiguration : BaseConfiguration<TipoTarjetaEntity>
    {
        public TipoTarjetaConfiguration()
        {
            ToTable("BOT_TIPO_TARJETA");
            HasKey(m => new { m.CodigoTipoTarjeta });

            Property(m => m.CodigoTipoTarjeta).HasColumnName("COD_TIPO_TARJETA");
            Property(m => m.DescripcionTipoTarjeta).HasColumnName("DES_TIPO_TARJETA");

            Ignore(g => g.EstadoObjeto);
        }
    }
}
