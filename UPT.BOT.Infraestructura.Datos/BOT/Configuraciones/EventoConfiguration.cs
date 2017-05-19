using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class EventoConfiguration : BaseConfiguration<EventoEntity>
    {
        public EventoConfiguration()
        {
            ToTable("BOT_EVENTO");
            HasKey(m => new { m.CodigoEvento });
            Property(m => m.CodigoEvento).HasColumnName("COD_EVENTO");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
            Property(m => m.FechaEvento).HasColumnName("FEC_EVENTO");
            Property(m => m.DescripcionLugar).HasColumnName("DES_LUGAR");
            Property(m => m.DescripcionMapa).HasColumnName("DES_MAPA");
            Property(m => m.IndicadorConcluido).HasColumnName("IND_CONCLUIDO");
        }
    }
}
