using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class ObjetoDto : BaseDto
    {
        public int CodigoObjeto { get; set; }
        public string DescripcionObjeto { get; set; }
        public string DescripcionControlador { get; set; }
        public string DescripcionAccion { get; set; }
        public string IndicadorHabilitado { get; set; }
    }
}
