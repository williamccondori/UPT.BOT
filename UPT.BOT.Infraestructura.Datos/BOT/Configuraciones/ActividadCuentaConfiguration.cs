using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class ActividadCuentaConfiguration : BaseConfiguration<ActividadCuentaEntity>
    {
        public ActividadCuentaConfiguration()
        {
            ToTable("BOT_ACTIVIDAD_CUENTA");
            HasKey(m => new { m.CodigoActividadCuenta });

            Property(m => m.CodigoActividadCuenta).HasColumnName("COD_ACTIVIDAD_CUENTA");
            Property(m => m.CodigoActividad).HasColumnName("COD_ACTIVIDAD");
            Property(m => m.DescripcionId).HasColumnName("DES_ID");
            Property(m => m.DescripcionNombre).HasColumnName("DES_NOMBRE");
            Property(m => m.IndicadorTipo).HasColumnName("IND_TIPO");
        }
    }
}
