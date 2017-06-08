using System;

namespace UPT.BOT.Aplicacion.DTOs.Shared
{
    public class BaseDto
    {
        public string IndicadorEstado { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
