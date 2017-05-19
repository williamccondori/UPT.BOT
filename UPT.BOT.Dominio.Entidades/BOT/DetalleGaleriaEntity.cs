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

        public DetalleGaleriaEntity()
        {

        }
    }
}
