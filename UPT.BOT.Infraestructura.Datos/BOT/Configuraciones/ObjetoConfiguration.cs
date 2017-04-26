using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    class ObjetoConfiguration : BaseConfiguration<ObjetoEntity>
    {
        public ObjetoConfiguration()
        {
            ToTable("BOT_OBJETO");
            HasKey(m => new { m.CodigoObjeto });

            Property(m => m.CodigoObjeto).HasColumnName("COD_OBJETO");
            Property(m => m.DescripcionObjeto).HasColumnName("DES_OBJETO");
            Property(m => m.DescripcionControlador).HasColumnName("DES_CONTROLADOR");
            Property(m => m.DescripcionAccion).HasColumnName("DES_ACCION");
            Property(m => m.IndicadorGeneral).HasColumnName("IND_GENERAL");
            Property(m => m.IndicadorHabilitado).HasColumnName("IND_HABILITADO");
        }
    }
}
