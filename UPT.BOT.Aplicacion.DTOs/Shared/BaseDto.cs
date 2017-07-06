using System;

namespace UPT.BOT.Aplicacion.DTOs.Shared
{
    public class BaseDto
    {
        public string IndicadorEstado { get; set; }
        public EstadoObjeto Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
