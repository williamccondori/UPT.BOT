using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class BuzonDto : BaseDto
    {
        public long CodigoBuzon { get; set; }
        public string CodigoTipoBuzon { get; set; }
        public string CodigoCliente { get; set; }
        public string DescripcionMensaje { get; set; }
        public string IndicadorLeido { get; set; }
        public string IndicadorGuardado { get; set; }
        public string IndicadorHistorial { get; set; }
    }
}
