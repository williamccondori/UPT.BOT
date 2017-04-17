using System;
using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class ActividadEntity : BaseEntity
    {
        public long CodigoActividad { get; set; }
        public string DescripcionIdActividad { get; set; }
        public string DescripcionIdCanal { get; set; }
        public string DescripcionLocalidad { get; set; }
        public string DescripcionUrlServicio { get; set; }
        public string DescripcionContenido { get; set; }
        public string DescripcionTipoContenido { get; set; }
        public DateTime? FechaMensaje { get; set; }
        public ICollection<ActividadCuentaEntity> ActividadCuentaS { get; set; }

        public static ActividadEntity Crear(
            string asDescripcionIdActividad,
            string asDescripcionIdActividadRespuesta,
            string asDescripcionAccion,
            string asDescripcionIdCanal,
            string asDescripcionLocalidad,
            string asDescripcionUrlServicio,
            string asDescripcionContenido,
            string asDescripcionTipoContenido,
            DateTime? adtFechaMensaje,
            string asCodigoUsuario,
            List<ActividadCuentaEntity> aoActividadCuentaS)
        {
            return new ActividadEntity
            {
                DescripcionIdActividad = asDescripcionIdActividad,
                DescripcionIdCanal = asDescripcionIdCanal,
                DescripcionLocalidad = asDescripcionLocalidad,
                DescripcionUrlServicio = asDescripcionUrlServicio,
                DescripcionContenido = asDescripcionContenido,
                DescripcionTipoContenido = asDescripcionTipoContenido,
                FechaMensaje = adtFechaMensaje,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = asCodigoUsuario,
                ActividadCuentaS = aoActividadCuentaS
            };
        }
    }
}
