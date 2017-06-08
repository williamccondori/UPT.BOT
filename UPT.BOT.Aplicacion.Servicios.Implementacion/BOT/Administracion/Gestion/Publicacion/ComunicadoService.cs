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
    public class ComunicadoService : BaseService, IComunicadoService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public ComunicadoService()
        {
            repositorioPublicacion = new PublicacionRepository(contexto);
        }

        public bool Eliminar(object id)
        {
            repositorioPublicacion.Eliminar(id);
            return true;
        }

        public bool Guardar(ComunicadoDto comunicado)
        {
            Validar(comunicado);

            if (comunicado.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                PublicacionEntity publicacion = PublicacionEntity.Crear(TipoPublicacionEntity.Comunicado, comunicado.DescripcionTitulo, comunicado.DescripcionImagen
                    , comunicado.DescripcionResumen, comunicado.DescripcionResena, comunicado.DescripcionUrl, comunicado.UsuarioRegistro);
                repositorioPublicacion.Crear(publicacion);
            }
            else if (comunicado.EstadoObjeto == EstadoObjeto.Modificado)
            {
                PublicacionEntity publicacion = repositorioPublicacion.Buscar(comunicado.CodigoPublicacion);
                publicacion.Modificar(comunicado.DescripcionTitulo, comunicado.DescripcionImagen, comunicado.DescripcionResumen
                    , comunicado.DescripcionResena, comunicado.DescripcionUrl, comunicado.IndicadorEstado, comunicado.UsuarioRegistro);
                repositorioPublicacion.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<ComunicadoDto> Obtener()
        {
            List<PublicacionEntity> Publicaciones = repositorioPublicacion.LeerXTipo(TipoPublicacionEntity.Comunicado).ToList();

            List<ComunicadoDto> Comunicadoes = Publicaciones.Select(p => new ComunicadoDto
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

            return Comunicadoes;
        }

        private void Validar(ComunicadoDto comunicado)
        {
            StringBuilder mensaje = new StringBuilder();

            if (comunicado == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = PublicacionEntity.Validar(comunicado.DescripcionTitulo, comunicado.DescripcionResena
                    , comunicado.DescripcionImagen, comunicado.DescripcionUrl);

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
