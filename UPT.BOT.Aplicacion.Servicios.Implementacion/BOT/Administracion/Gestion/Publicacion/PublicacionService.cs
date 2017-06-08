using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Publicacion;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Publicacion
{
    public class PublicacionService : IPublicacionService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public PublicacionService()
        {
            repositorioPublicacion = new PublicacionRepository(new BotContext());
        }

        public bool Eliminar(object id)
        {
            repositorioPublicacion.Eliminar(id);
            return true;
        }

        public bool Guardar(PublicacionDto Publicacion)
        {
            Validar(Publicacion);

            if (Publicacion.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                PublicacionEntity Publicacion = PublicacionEntity.Crear(TipoPublicacionEntity.Publicacion, Publicacion.DescripcionTitulo
                    , Publicacion.DescripcionResena, Publicacion.DescripcionPublicacion, Publicacion.DescripcionUrl, Publicacion.UsuarioRegistro, null);
                repositorioPublicacion.Crear(Publicacion);
            }
            else if (Publicacion.EstadoObjeto == EstadoObjeto.Modificado)
            {
                PublicacionEntity Publicacion = repositorioPublicacion.Buscar(Publicacion.CodigoPublicacion);
                Publicacion.Modificar(Publicacion.DescripcionTitulo, Publicacion.DescripcionResena
                    , Publicacion.DescripcionPublicacion, Publicacion.DescripcionUrl, Publicacion.UsuarioRegistro, Publicacion.IndicadorEstado, null);
                repositorioPublicacion.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<PublicacionDto> Obtener()
        {
            List<PublicacionEntity> Publicacions = repositorioPublicacion.LeerXTipo(TipoPublicacionEntity.Publicacion).ToList();

            List<PublicacionDto> Publicaciones = Publicacions.Select(p => new PublicacionDto
            {
                CodigoPublicacion = p.CodigoPublicacion,
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionContenido = p.DescripcionContenido,
                DescripcionPublicacion = p.DescripcionPublicacion,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return Publicaciones;
        }

        private void Validar(PublicacionDto Publicacion)
        {
            StringBuilder mensaje = new StringBuilder();

            if (Publicacion == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = PublicacionEntity.Validar(Publicacion.DescripcionTitulo, Publicacion.DescripcionResena
                    , Publicacion.DescripcionPublicacion, Publicacion.DescripcionUrl);

                mensaje.Append(mensajeValidacion);
            }

            if (mensaje.Length > 0)
            {
                StringBuilder validacion = new StringBuilder();
                validacion.Append("Validaciones: ");
                validacion.Append(mensaje.ToString());
                throw new Exception(validacion.ToString());
            }
        }
    }
}
