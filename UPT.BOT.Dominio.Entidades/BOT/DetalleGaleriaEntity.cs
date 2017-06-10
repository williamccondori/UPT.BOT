using System;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class DetalleGaleriaEntity : BaseEntity
    {
        public long CodigoDetalleGaleria { get; set; }
        public long CodigoGaleria { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string IndicadorHabilitado { get; set; }
        public GaleriaEntity GaleriaX { get; set; }

        public DetalleGaleriaEntity()
        {

        }

        public static DetalleGaleriaEntity Crear(long codigoGaleria, string descripcionTitulo, string descripcionImagen
            , string descripcionResena, string usuario)
        {
            return new DetalleGaleriaEntity
            {
                CodigoGaleria = codigoGaleria,
                DescripcionTitulo = descripcionTitulo,
                DescripcionImagen = descripcionImagen,
                DescripcionResena = descripcionResena,
                IndicadorHabilitado = "S",
                IndicadorEstado = "A",
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                UsuarioRegistro = usuario
            };
        } 

        public void Eliminar()
        {
            EstadoObjeto = EstadoObjeto.Borrado;
        }
    }
}
