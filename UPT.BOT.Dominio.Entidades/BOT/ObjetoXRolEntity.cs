namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class ObjetoXRolEntity : BaseEntity
    {
        public int CodigoObjetoXRol { get; set; }
        public int CodigoObjeto { get; set; }
        public int CodigoRol { get; set; }
        public string IndicadorHabilitado { get; set; }
    }
}
