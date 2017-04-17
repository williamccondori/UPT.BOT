using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class ActividadConfiguration : BaseConfiguration<ActividadEntity>
    {
        public ActividadConfiguration()
        {
            ToTable("BOT_ACTIVIDAD");
            HasKey(m => new { m.CodigoActividad });

            Property(m => m.CodigoActividad).HasColumnName("COD_ACTIVIDAD");
            Property(m => m.DescripcionIdActividad).HasColumnName("DES_ID_ACTIVIDAD");
            Property(m => m.DescripcionIdCanal).HasColumnName("DES_ID_CANAL");
            Property(m => m.DescripcionLocalidad).HasColumnName("DES_LOCALIDAD");
            Property(m => m.DescripcionUrlServicio).HasColumnName("DES_URL_SERVICIO");
            Property(m => m.DescripcionContenido).HasColumnName("DES_CONTENIDO");
            Property(m => m.DescripcionTipoContenido).HasColumnName("DES_TIPO_CONTENIDO");
            Property(m => m.FechaMensaje).HasColumnName("FEC_MENSAJE");

            //HasRequired(g => g.TipoDocumentoX).WithMany().HasForeignKey(g => g.CodigoTipoDocumento);
            HasMany(g => g.ActividadCuentaS).WithRequired().HasForeignKey(g => g.CodigoActividad);
        }
    }
}
