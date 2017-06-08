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
    public class ComunicadoService : IComunicadoService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public ComunicadoService()
        {
            repositorioPublicacion = new PublicacionRepository(new BotContext());
        }

        public bool Eliminar(object id)
        {
            repositorioPublicacion.Eliminar(id);
            return true;
        }

        public bool Guardar(ComunicadoDto Comunicado)
        {
            Validar(Comunicado);

            if (Comunicado.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                PublicacionEntity Publicacion = PublicacionEntity.Crear(TipoPublicacionEntity.Comunicado, Comunicado.DescripcionTitulo
                    , Comunicado.DescripcionResena, Comunicado.DescripcionComunicado, Comunicado.DescripcionUrl, Comunicado.UsuarioRegistro, null);
                repositorioPublicacion.Crear(Publicacion);
            }
            else if (Comunicado.EstadoObjeto == EstadoObjeto.Modificado)
            {
                PublicacionEntity Publicacion = repositorioPublicacion.Buscar(Comunicado.CodigoPublicacion);
                Publicacion.Modificar(Comunicado.DescripcionTitulo, Comunicado.DescripcionResena
                    , Comunicado.DescripcionComunicado, Comunicado.DescripcionUrl, Comunicado.UsuarioRegistro, Comunicado.IndicadorEstado, null);
                repositorioPublicacion.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<ComunicadoDto> Obtener()
        {
            List<PublicacionEntity> Publicacions = repositorioPublicacion.LeerXTipo(TipoPublicacionEntity.Comunicado).ToList();

            List<ComunicadoDto> Comunicadoes = Publicacions.Select(p => new ComunicadoDto
            {
                CodigoPublicacion = p.CodigoPublicacion,
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionContenido = p.DescripcionContenido,
                DescripcionComunicado = p.DescripcionComunicado,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return Comunicadoes;
        }

        private void Validar(ComunicadoDto Comunicado)
        {
            StringBuilder mensaje = new StringBuilder();

            if (Comunicado == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = PublicacionEntity.Validar(Comunicado.DescripcionTitulo, Comunicado.DescripcionResena
                    , Comunicado.DescripcionComunicado, Comunicado.DescripcionUrl);

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
