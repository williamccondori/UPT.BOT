using System;
using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class UsuarioEntity : BaseEntity
    {
        public int CodigoUsuario { get; set; }
        public string DescripcionNombre { get; set; }
        public string DescripcionApellido { get; set; }
        public string DescripcionEmail { get; set; }
        public string DescripcionUsuario { get; set; }
        public string DescripcionPassword { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string IndicadorHabilitado { get; set; }

        public ICollection<UsuarioXRolEntity> UsuarioXRolS { get; set; }

        public static UsuarioEntity Crear(
            string asDescripcionNombre
            , string asDescripcionApellido
            , string asDescripcionEmail
            , string asDescripcionUsuario
            , string asDescripcionPassword
            , string asDescripcionImagen
            , string asDescripcionResena
            , string asIndicadorHabilitado
            , string asUsuario)
        {
            return new UsuarioEntity
            {
                DescripcionNombre = asDescripcionNombre,
                DescripcionApellido = asDescripcionApellido,
                DescripcionEmail = asDescripcionEmail,
                DescripcionUsuario = asDescripcionUsuario,
                DescripcionPassword = asDescripcionPassword,
                DescripcionImagen = asDescripcionImagen,
                DescripcionResena = asDescripcionResena,
                IndicadorHabilitado = asIndicadorHabilitado,
                UsuarioRegistro = asUsuario,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                EstadoObjeto = EstadoObjeto.Nuevo
            };
        }

        public void Modificar(
            string asDescripcionNombre
            , string asDescripcionApellido
            , string asDescripcionEmail
            , string asDescripcionUsuario
            , string asDescripcionPassword
            , string asDescripcionImagen
            , string asDescripcionResena
            , string asIndicadorHabilitado
            , string asUsuario)
        {
            DescripcionNombre = asDescripcionNombre;
            DescripcionApellido = asDescripcionApellido;
            DescripcionEmail = asDescripcionEmail;
            DescripcionUsuario = asDescripcionUsuario;
            DescripcionPassword = asDescripcionPassword;
            DescripcionImagen = asDescripcionImagen;
            DescripcionResena = asDescripcionResena;
            IndicadorHabilitado = asIndicadorHabilitado;
            UsuarioRegistro = asUsuario;
            FechaRegistro = DateTime.Now;
            IndicadorEstado = EstadoEntidad.Activo;
            EstadoObjeto = EstadoObjeto.Modificado;
        }
    }
}
