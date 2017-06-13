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
    public class AdmisionService : BaseService, IAdmisionService
    {
        private readonly IAdmisionRepository repositorioAdmision;

        public AdmisionService()
        {
            repositorioAdmision = new AdmisionRepository(contexto);
        }

        public List<AdmisionDto> Obtener()
        {
            List<AdmisionEntity> listaAdmision = repositorioAdmision.Leer().Take(5).ToList();

            return listaAdmision.Select(p => new AdmisionDto
            {
                CodigoAdmision = p.CodigoAdmision,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorConcluido = p.IndicadorConcluido
            }).ToList();
        }
    }
}
