using System;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT.Asistente
{
    public class ActividadDto : BaseDto
    {
        public long CodigoActividad { get; set; }
        public string DescripcionIdActividad { get; set; }
        public string DescripcionIdActividadRespuesta { get; set; }
        public string DescripcionAccion { get; set; }
        public string DescripcionIdCanal { get; set; }
        public string DescripcionLocalidad { get; set; }
        public string DescripcionUrlServicio { get; set; }
        public string DescripcionContenido { get; set; }
        public string DescripcionTipoContenido { get; set; }
        public DateTime? FechaMensaje { get; set; }
        public ActividadCuentaDto Emisor { get; set; }
        public ActividadCuentaDto Receptor { get; set; }
    }
}
