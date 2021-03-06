﻿using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class DetalleGaleriaConfiguration : BaseConfiguration<DetalleGaleriaEntity>
    {
        public DetalleGaleriaConfiguration()
        {
            ToTable("BOT_DETALLE_GALERIA");
            HasKey(m => new { m.CodigoDetalleGaleria });
            Property(m => m.CodigoDetalleGaleria).HasColumnName("COD_DETALLE_GALERIA");
            Property(m => m.CodigoGaleria).HasColumnName("COD_GALERIA");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionImagen).HasColumnName("DES_IMAGEN");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.IndicadorHabilitado).HasColumnName("IND_HABILITADO");

            HasRequired(m => m.GaleriaX).WithMany().HasForeignKey(m => m.CodigoGaleria);
        }
    }
}
