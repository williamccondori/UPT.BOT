using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class ObjetoEntity : BaseEntity
    {
        public int CodigoObjeto { get; set; }
        public string DescripcionObjeto { get; set; }
        public string DescripcionControlador { get; set; }
        public string DescripcionAccion { get; set; }
        public string IndicadorGeneral { get; set; }
        public string IndicadorHabilitado { get; set; }
    }
}
