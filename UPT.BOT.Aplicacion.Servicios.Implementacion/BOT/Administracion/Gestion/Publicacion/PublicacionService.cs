using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Publicacion
{
    public class PublicacionService : BaseService, IPublicacionService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public PublicacionService()
        {
            repositorioPublicacion = new PublicacionRepository(contexto);
        }

        public bool Eliminar(object id)
        {
            repositorioPublicacion.Eliminar(id);
            return true;
        }

        public bool Guardar(PublicacionDto publicacion)
        {
            Validar(publicacion);

            if (publicacion.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                PublicacionEntity publicacion_ = PublicacionEntity.Crear(TipoPublicacionEntity.Publicacion, publicacion.DescripcionTitulo, publicacion.DescripcionImagen
                    , publicacion.DescripcionResumen, publicacion.DescripcionResena, publicacion.DescripcionUrl, publicacion.UsuarioRegistro);
                repositorioPublicacion.Crear(publicacion_);
            }
            else if (publicacion.EstadoObjeto == EstadoObjeto.Modificado)
            {
                PublicacionEntity publicacion_ = repositorioPublicacion.Buscar(publicacion.CodigoPublicacion);
                publicacion_.Modificar(publicacion.DescripcionTitulo, publicacion.DescripcionImagen, publicacion.DescripcionResumen
                    , publicacion.DescripcionResena, publicacion.DescripcionUrl, publicacion.IndicadorEstado, publicacion.UsuarioRegistro);
                repositorioPublicacion.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<PublicacionDto> Obtener()
        {
            List<PublicacionEntity> publicaciones = repositorioPublicacion.LeerXTipo(TipoPublicacionEntity.Publicacion).ToList();

            List<PublicacionDto> publicaciones_ = publicaciones.Select(p => new PublicacionDto
            {
                CodigoPublicacion = p.CodigoPublicacion,
                DescripcionResena = p.DescripcionResena,
                DescripcionResumen = p.DescripcionResumen,
                DescripcionImagen = p.DescripcionImagen,
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return publicaciones_;
        }

        private void Validar(PublicacionDto Publicacion)
        {
            StringBuilder mensaje = new StringBuilder();

            if (Publicacion == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = PublicacionEntity.Validar(Publicacion.DescripcionTitulo, Publicacion.DescripcionResena
                    , Publicacion.DescripcionImagen, Publicacion.DescripcionUrl);

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
