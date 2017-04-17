namespace UPT.BOT.Aplicacion.DTOs.BOT.Asistente
{
    public class ActividadCuentaDto
    {
        public long CodigoActividadCuenta { get; set; }
        public string DescripcionId { get; set; }
        public string DescripcionNombre { get; set; }
        public string IndicadorTipo { get; set; }

        public const string Emisor = "E";
        public const string Receptor = "R";
    }
}
