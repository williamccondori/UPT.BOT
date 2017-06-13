using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion
{
    public class DireccionService : BaseService, IDireccionService
    {
        private readonly IDireccionRepository repositorioDireccion;

        public DireccionService()
        {
            repositorioDireccion = new DireccionRepository(contexto);
        }

        public List<DireccionDto> Obtener()
        {
            List<DireccionEntity> listaDireccion = repositorioDireccion.Leer().Take(5).ToList();

            return listaDireccion.Select(p => new DireccionDto
            {
                CodigoDireccion = p.CodigoDireccion,
                DescripcionDireccion = p.DescripcionDireccion,
                DescripcionMapa = p.DescripcionMapa,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
