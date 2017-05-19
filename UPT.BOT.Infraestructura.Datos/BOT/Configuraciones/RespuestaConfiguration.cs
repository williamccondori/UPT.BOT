using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class RespuestaConfiguration : BaseConfiguration<RespuestaEntity>
    {
        public RespuestaConfiguration()
        {
            ToTable("BOT_RESPUESTA");
            HasKey(m => new { m.CodigoRespuesta });
            Property(m => m.CodigoRespuesta).HasColumnName("COD_RESPUESTA");
            Property(m => m.CodigoAlternativa).HasColumnName("COD_ALTERNATIVA");
            Property(m => m.CodigoCliente).HasColumnName("COD_CLIENTE");
            Property(m => m.FechaRespuesta).HasColumnName("FEC_RESPUESTA");
        }
    }
}
