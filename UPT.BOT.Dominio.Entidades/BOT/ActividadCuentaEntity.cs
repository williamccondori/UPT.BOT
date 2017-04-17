using System;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class ActividadCuentaEntity : BaseEntity
    {
        public long CodigoActividadCuenta { get; set; }
        public long CodigoActividad { get; set; }
        public string DescripcionId { get; set; }
        public string DescripcionNombre { get; set; }
        public string IndicadorTipo { get; set; }

        public static ActividadCuentaEntity Crear(
            string asDescripcionId,
            string asDescripcionNombre,
            string asIndicadorTipo,
            string asCodigoUsuario)
        {
            return new ActividadCuentaEntity
            {
                DescripcionId = asDescripcionId,
                DescripcionNombre = asDescripcionNombre,
                IndicadorTipo = asIndicadorTipo,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = asCodigoUsuario
            };
        }
    }
}
