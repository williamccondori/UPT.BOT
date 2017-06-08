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
    public class ActualidadService : IActualidadService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public ActualidadService()
        {
            repositorioPublicacion = new PublicacionRepository(new BotContext());
        }

        public bool Eliminar(object id)
        {
            repositorioPublicacion.Eliminar(id);
            return true;
        }

        public bool Guardar(ActualidadDto Actualidad)
        {
            Validar(Actualidad);

            if (Actualidad.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                PublicacionEntity Publicacion = PublicacionEntity.Crear(TipoPublicacionEntity.Actualidad, Actualidad.DescripcionTitulo
                    , Actualidad.DescripcionResena, Actualidad.DescripcionActualidad, Actualidad.DescripcionUrl, Actualidad.UsuarioRegistro, null);
                repositorioPublicacion.Crear(Publicacion);
            }
            else if (Actualidad.EstadoObjeto == EstadoObjeto.Modificado)
            {
                PublicacionEntity Publicacion = repositorioPublicacion.Buscar(Actualidad.CodigoPublicacion);
                Publicacion.Modificar(Actualidad.DescripcionTitulo, Actualidad.DescripcionResena
                    , Actualidad.DescripcionActualidad, Actualidad.DescripcionUrl, Actualidad.UsuarioRegistro, Actualidad.IndicadorEstado, null);
                repositorioPublicacion.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<ActualidadDto> Obtener()
        {
            List<PublicacionEntity> Publicacions = repositorioPublicacion.LeerXTipo(TipoPublicacionEntity.Actualidad).ToList();

            List<ActualidadDto> Actualidades = Publicacions.Select(p => new ActualidadDto
            {
                CodigoPublicacion = p.CodigoPublicacion,
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionContenido = p.DescripcionContenido,
                DescripcionActualidad = p.DescripcionActualidad,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return Actualidades;
        }

        private void Validar(ActualidadDto Actualidad)
        {
            StringBuilder mensaje = new StringBuilder();

            if (Actualidad == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = PublicacionEntity.Validar(Actualidad.DescripcionTitulo, Actualidad.DescripcionResena
                    , Actualidad.DescripcionActualidad, Actualidad.DescripcionUrl);

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
