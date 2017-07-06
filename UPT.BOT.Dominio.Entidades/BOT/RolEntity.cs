using System;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class RolEntity : BaseEntity
    {
        public string CodigoRol { get; set; }
        public string DescripcionRol { get; set; }

        public RolEntity()
        {

        }

        public static RolEntity Crear(string descripcionRol, string usuario)
        {
            return new RolEntity
            {
                DescripcionRol = descripcionRol,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = usuario
            };
        }

        public void Modificar(string descripcionRol, string usuario)
        {
            DescripcionRol = descripcionRol;
            UsuarioModifico = usuario;
            FechaModifico = DateTime.Now;
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
