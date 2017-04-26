using System;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion
{
    public class RolDto : BaseDto
    {
        public int CodigoRol { get; set; }
        public string DescripcionRol { get; set; }
    }

    public class RolRegistroDto : RolDto
    {
        public string Usuario { get; set; }
    }

    public class RolConsultaDto : RolDto
    {
        public DateTime FechaRegistro { get; set; }
    }
}
