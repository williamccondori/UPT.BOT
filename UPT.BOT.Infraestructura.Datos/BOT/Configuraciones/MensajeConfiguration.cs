using System.Data.Entity.ModelConfiguration;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class MensajeConfiguration : EntityTypeConfiguration<MensajeEntity>
    {
        public MensajeConfiguration()
        {
            ToTable("BOT_MENSAJE");
            HasKey(m => new { m.CodigoMensaje });
            Property(m => m.CodigoMensaje).HasColumnName("COD_MENSAJE");
            Property(m => m.CodigoCliente).HasColumnName("COD_CLIENTE");
            Property(m => m.DescripcionActividad).HasColumnName("DES_ACTIVIDAD");
            Property(m => m.DescripcionCanal).HasColumnName("DES_CANAL");
            Property(m => m.DescripcionLocalidad).HasColumnName("DES_LOCALIDAD");
            Property(m => m.DescripcionServicio).HasColumnName("DES_SERVICIO");
            Property(m => m.DescripcionContenido).HasColumnName("DES_CONTENIDO");
            Property(m => m.DescripcionTipoContenido).HasColumnName("DES_TIPO_CONTENIDO");
            Property(m => m.DescripcionIntencion).HasColumnName("DES_INTENCION");
            Property(m => m.PorIntencion).HasColumnName("POR_INTENCION");
            Property(m => m.FechaMensaje).HasColumnName("FEC_MENSAJE");
            Ignore(g => g.EstadoObjeto);
        }
    }
}
