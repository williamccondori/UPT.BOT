using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion
{
    public class EventoService : BaseService, IEventoService
    {
        private readonly IEventoRepository repositorioEvento;

        public EventoService()
        {
            repositorioEvento = new EventoRepository(contexto);
        }

        public IList<EventoDto> Obtener()
        {
            List<EventoEntity> listaPublicacion = repositorioEvento
                .Leer().Take(5).ToList();

            return listaPublicacion.Select(p => new EventoDto
            {
                CodigoEvento = p.CodigoEvento,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionLugar = p.DescripcionLugar,
                DescripcionMapa = p.DescripcionMapa,
                DescripcionResena = p.DescripcionResena,
                FechaEvento = p.FechaEvento,
                FechaRegistro = p.FechaRegistro,
                IndicadorConcluido = p.IndicadorConcluido,
                IndicadorEstado = p.IndicadorEstado,
                UsuarioRegistro = p.UsuarioRegistro,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
