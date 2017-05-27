using System;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class ClienteDto : BaseDto
    {
        public string CodigoCliente { get; set; }
        public string DescripcionNombre { get; set; }
        public string DescripcionCanal { get; set; }
        public string DescripcionConversacion { get; set; }
        public string DescripcionMetadata { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
