using System;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class RolEntity : BaseEntity
    {
        public int CodigoRol { get; set; }
        public string DescripcionRol { get; set; }

        public static RolEntity Crear(
            string asDescripcionRol
            , string asUsuario)
        {
            return new RolEntity
            {
                DescripcionRol = asDescripcionRol,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = asUsuario
            };
        }

        public void Modificar(
            string asDescripcionRol
            , string asUsuario)
        {
            DescripcionRol = asDescripcionRol;
            FechaModifico = DateTime.Now;
            UsuarioModifico = asUsuario;
            EstadoObjeto = EstadoObjeto.Modificado;
        }
    }
}
