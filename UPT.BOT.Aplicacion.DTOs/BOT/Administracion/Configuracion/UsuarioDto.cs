using System;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion
{
    public class UsuarioDto : BaseDto
    {
        public int CodigoUsuario { get; set; }
        public string DescripcionNombre { get; set; }
        public string DescripcionApellido { get; set; }
        public string DescripcionEmail { get; set; }
        public string DescripcionUsuario { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public bool IndicadorHabilitado { get; set; }
    }

    public class UsuarioConsultaDto : UsuarioDto
    {
        public DateTime FechaRegistro { get; set; }
    }

    public class UsuarioRegistroDto : UsuarioDto
    {
        public string DescripcionPassword { get; set; }
        public string DescripcionPasswordAdicional { get; set; }
        public string Usuario { get; set; }
    }
}
