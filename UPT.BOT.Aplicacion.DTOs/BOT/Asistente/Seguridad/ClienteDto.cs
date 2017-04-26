using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad
{
    public class ClienteDto
    {
        public string CodigoCliente { get; set; }
        public string DescripcionCanal { get; set; }
        public string DescripcionId { get; set; }
        public string DescripcionNombre { get; set; }
        public string DescripcionConversacion { get; set; }
        public string DescripcionConversacionNombre { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }
    }
}
