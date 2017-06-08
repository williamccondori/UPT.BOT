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
    public class GaleriaService : IGaleriaService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public GaleriaService()
        {
            repositorioPublicacion = new PublicacionRepository(new BotContext());
        }

        public bool Eliminar(object id)
        {
            repositorioPublicacion.Eliminar(id);
            return true;
        }

        public bool Guardar(GaleriaDto Galeria)
        {
            Validar(Galeria);

            if (Galeria.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                PublicacionEntity Publicacion = PublicacionEntity.Crear(TipoPublicacionEntity.Galeria, Galeria.DescripcionTitulo
                    , Galeria.DescripcionResena, Galeria.DescripcionGaleria, Galeria.DescripcionUrl, Galeria.UsuarioRegistro, null);
                repositorioPublicacion.Crear(Publicacion);
            }
            else if (Galeria.EstadoObjeto == EstadoObjeto.Modificado)
            {
                PublicacionEntity Publicacion = repositorioPublicacion.Buscar(Galeria.CodigoPublicacion);
                Publicacion.Modificar(Galeria.DescripcionTitulo, Galeria.DescripcionResena
                    , Galeria.DescripcionGaleria, Galeria.DescripcionUrl, Galeria.UsuarioRegistro, Galeria.IndicadorEstado, null);
                repositorioPublicacion.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<GaleriaDto> Obtener()
        {
            List<PublicacionEntity> Publicacions = repositorioPublicacion.LeerXTipo(TipoPublicacionEntity.Galeria).ToList();

            List<GaleriaDto> Galeriaes = Publicacions.Select(p => new GaleriaDto
            {
                CodigoPublicacion = p.CodigoPublicacion,
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionContenido = p.DescripcionContenido,
                DescripcionGaleria = p.DescripcionGaleria,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return Galeriaes;
        }

        private void Validar(GaleriaDto Galeria)
        {
            StringBuilder mensaje = new StringBuilder();

            if (Galeria == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = PublicacionEntity.Validar(Galeria.DescripcionTitulo, Galeria.DescripcionResena
                    , Galeria.DescripcionGaleria, Galeria.DescripcionUrl);

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
