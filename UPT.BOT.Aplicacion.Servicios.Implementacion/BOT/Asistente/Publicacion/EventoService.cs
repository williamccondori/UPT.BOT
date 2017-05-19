using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository repositorioEvento;

        public EventoService()
        {
            repositorioEvento = new EventoRepository(new BotContext());
        }

        public IList<EventoDto> Obtener()
        {
            IEnumerable<EventoEntity> listaEvento = repositorioEvento.Leer().Where(p => p.IndicadorConcluido == Indicador.Si).Take(5);

            return listaEvento.Select(p => new EventoDto
            {
                IndicadorConcluido = p.IndicadorConcluido,
                CodigoEvento = p.CodigoEvento,
                DescripcionLugar = p.DescripcionLugar,
                DescripcionMapa = p.DescripcionMapa,
                FechaEvento = p.FechaEvento,
                DescripcionResena = p.DescripcionResena,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
