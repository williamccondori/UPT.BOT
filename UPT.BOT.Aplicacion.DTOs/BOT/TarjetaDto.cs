using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class TarjetaDto : BaseDto
    {
        public int CodigoTarjeta { get; set; }
        public string CodigoTipoTarjeta { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionSubtitulo { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionUrl { get; set; }
        public string IndicadorHabilitado { get; set; }

        public TipoTarjetaDto TipoTarjeta { get; set; }
    }
}
