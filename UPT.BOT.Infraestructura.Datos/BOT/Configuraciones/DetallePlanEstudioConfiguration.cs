﻿using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class DetallePlanEstudioConfiguration : BaseConfiguration<DetallePlanEstudioEntity>
    {
        public DetallePlanEstudioConfiguration()
        {
            ToTable("BOT_DETALLE_PLAN_ESTUDIO");
            HasKey(m => new { m.CodigoDetallePlanEstudio });
            Property(m => m.CodigoDetallePlanEstudio).HasColumnName("COD_DETALLE_PLAN_ESTUDIO");
            Property(m => m.CodigoPlanEstudio).HasColumnName("COD_PLAN_ESTUDIO");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
        }
    }
}
