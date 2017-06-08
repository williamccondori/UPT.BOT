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
    public class ActualidadService : BaseService, IActualidadService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public ActualidadService()
        {
            repositorioPublicacion = new PublicacionRepository(contexto);
        }

        public bool Eliminar(object id)
        {
            repositorioPublicacion.Eliminar(id);
            return true;
        }

        public bool Guardar(ActualidadDto actualidad)
        {
            Validar(actualidad);

            if (actualidad.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                PublicacionEntity publicacion = PublicacionEntity.Crear(TipoPublicacionEntity.Actualidad, actualidad.DescripcionTitulo, actualidad.DescripcionImagen
                    , actualidad.DescripcionResumen, actualidad.DescripcionResena, actualidad.DescripcionUrl, actualidad.UsuarioRegistro);
                repositorioPublicacion.Crear(publicacion);
            }
            else if (actualidad.EstadoObjeto == EstadoObjeto.Modificado)
            {
                PublicacionEntity publicacion = repositorioPublicacion.Buscar(actualidad.CodigoPublicacion);
                publicacion.Modificar(actualidad.DescripcionTitulo, actualidad.DescripcionImagen, actualidad.DescripcionResumen
                    , actualidad.DescripcionResena, actualidad.DescripcionUrl, actualidad.IndicadorEstado, actualidad.UsuarioRegistro);
                repositorioPublicacion.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<ActualidadDto> Obtener()
        {
            List<PublicacionEntity> Publicaciones = repositorioPublicacion.LeerXTipo(TipoPublicacionEntity.Actualidad).ToList();

            List<ActualidadDto> Actualidades = Publicaciones.Select(p => new ActualidadDto
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

            return Actualidades;
        }

        private void Validar(ActualidadDto actualidad)
        {
            StringBuilder mensaje = new StringBuilder();

            if (actualidad == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = PublicacionEntity.Validar(actualidad.DescripcionTitulo, actualidad.DescripcionResena
                    , actualidad.DescripcionImagen, actualidad.DescripcionUrl);

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
