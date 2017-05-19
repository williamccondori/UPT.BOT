using System.Data.Entity.ModelConfiguration;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class ClienteConfiguration : EntityTypeConfiguration<ClienteEntity>
    {
        public ClienteConfiguration()
        {
            ToTable("BOT_CLIENTE");
            HasKey(m => new { m.CodigoCliente });
            Property(m => m.CodigoCliente).HasColumnName("COD_CLIENTE");
            Property(m => m.DescripcionNombre).HasColumnName("DES_NOMBRE");
            Property(m => m.DescripcionCanal).HasColumnName("DES_CANAL");
            Property(m => m.DescripcionConversacion).HasColumnName("DES_CONVERSACION");
            Property(m => m.DescripcionConversacionNombre).HasColumnName("DES_CONVERSACION_NOMBRE");
            Property(m => m.FechaRegistro).HasColumnName("FEC_REGISTRO");
            Ignore(g => g.EstadoObjeto);
        }
    }
}
