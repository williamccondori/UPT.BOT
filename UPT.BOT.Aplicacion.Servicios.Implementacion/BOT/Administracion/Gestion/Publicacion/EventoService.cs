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
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Publicacion
{
    public class EventoService : BaseService, IEventoService
    {
        private readonly IEventoRepository repositorioEvento;

        public EventoService()
        {
            repositorioEvento = new EventoRepository(contexto);
        }

        public bool Eliminar(object id)
        {
            repositorioEvento.Eliminar(id);
            return true;
        }

        public bool Guardar(EventoDto evento)
        {
            Validar(evento);

            if (evento.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                EventoEntity evento_ = EventoEntity.Crear(evento.DescripcionTitulo, evento.DescripcionImagen, evento.DescripcionResena, evento.DescripcionUrl
                    , evento.FechaEvento, evento.DescripcionLugar, evento.DescripcionMapa, evento.IndicadorConcluido, evento.UsuarioRegistro);
                repositorioEvento.Crear(evento_);
            }
            else if (evento.EstadoObjeto == EstadoObjeto.Modificado)
            {
                EventoEntity evento_ = repositorioEvento.Buscar(evento.CodigoEvento);
                evento_.Modificar(evento.DescripcionTitulo, evento.DescripcionImagen, evento.DescripcionResena, evento.DescripcionUrl
                    , evento.FechaEvento, evento.DescripcionLugar, evento.DescripcionMapa, evento.IndicadorConcluido, evento.IndicadorEstado, evento.UsuarioRegistro);
                repositorioEvento.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<EventoDto> Obtener()
        {
            List<EventoEntity> eventos = repositorioEvento.Leer().ToList();

            List<EventoDto> eventos_ = eventos.Select(p => new EventoDto
            {
                CodigoEvento = p.CodigoEvento,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionLugar = p.DescripcionLugar,
                DescripcionMapa = p.DescripcionMapa,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                FechaEvento = p.FechaEvento,
                IndicadorConcluido = p.IndicadorConcluido,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return eventos_;
        }

        private void Validar(EventoDto evento)
        {
            StringBuilder mensaje = new StringBuilder();

            if (evento == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = PublicacionEntity.Validar(evento.DescripcionTitulo, evento.DescripcionResena, evento.DescripcionImagen
                    , evento.DescripcionUrl);

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
