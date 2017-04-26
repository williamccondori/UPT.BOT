using System;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad
{
    public class MensajeDto
    {
        public string CodigoCliente { get; set; }
        public string DescripcionActividad { get; set; }
        public string DescripcionCanal { get; set; }
        public string DescripcionLocalidad { get; set; }
        public string DescripcionServicio { get; set; }
        public string DescripcionContenido { get; set; }
        public string DescripcionTipoContenido { get; set; }
        public string DescripcionIntencion { get; set; }
        public decimal PorcentajeIntencion { get; set; }
        public DateTime? FechaMensaje { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }
    }
}
