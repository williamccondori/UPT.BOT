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
    public class EnlaceImportanteService : BaseService, IEnlaceImportanteService
    {
        private readonly IEnlaceImportanteRepository repositorioEnlaceImportante;

        public EnlaceImportanteService()
        {
            repositorioEnlaceImportante = new EnlaceImportanteRepository(contexto);
        }

        public List<EnlaceImportanteDto> Obtener()
        {
            List<EnlaceImportanteEntity> listaEnlacesImportantes = repositorioEnlaceImportante.Leer().Take(5).ToList();

            return listaEnlacesImportantes.Select(p => new EnlaceImportanteDto
            {
                CodigoEnlace = p.CodigoEnlace,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
            }).ToList();
        }
    }
}
