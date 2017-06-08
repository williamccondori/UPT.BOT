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
    public class EventoService : IEventoService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public EventoService()
        {
            repositorioPublicacion = new PublicacionRepository(new BotContext());
        }

        public bool Eliminar(object id)
        {
            repositorioPublicacion.Eliminar(id);
            return true;
        }

        public bool Guardar(EventoDto Evento)
        {
            Validar(Evento);

            if (Evento.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                PublicacionEntity Publicacion = PublicacionEntity.Crear(TipoPublicacionEntity.Evento, Evento.DescripcionTitulo
                    , Evento.DescripcionResena, Evento.DescripcionEvento, Evento.DescripcionUrl, Evento.UsuarioRegistro, null);
                repositorioPublicacion.Crear(Publicacion);
            }
            else if (Evento.EstadoObjeto == EstadoObjeto.Modificado)
            {
                PublicacionEntity Publicacion = repositorioPublicacion.Buscar(Evento.CodigoPublicacion);
                Publicacion.Modificar(Evento.DescripcionTitulo, Evento.DescripcionResena
                    , Evento.DescripcionEvento, Evento.DescripcionUrl, Evento.UsuarioRegistro, Evento.IndicadorEstado, null);
                repositorioPublicacion.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<EventoDto> Obtener()
        {
            List<PublicacionEntity> Publicacions = repositorioPublicacion.LeerXTipo(TipoPublicacionEntity.Evento).ToList();

            List<EventoDto> Eventoes = Publicacions.Select(p => new EventoDto
            {
                CodigoPublicacion = p.CodigoPublicacion,
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionContenido = p.DescripcionContenido,
                DescripcionEvento = p.DescripcionEvento,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return Eventoes;
        }

        private void Validar(EventoDto Evento)
        {
            StringBuilder mensaje = new StringBuilder();

            if (Evento == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = PublicacionEntity.Validar(Evento.DescripcionTitulo, Evento.DescripcionResena
                    , Evento.DescripcionEvento, Evento.DescripcionUrl);

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
