using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.PlanEstudio;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Planestudio
{
    public class PerfilProfesionalService : BaseService, IPerfilProfesionalService
    {
        private readonly IAdjuntoRepository repositorioAdjunto;

        public PerfilProfesionalService()
        {
            repositorioAdjunto = new AdjuntoRepository(contexto);
        }

        public List<PerfilProfesionalDto> Obtener()
        {
            List<AdjuntoEntity> listaAdjunto = repositorioAdjunto.LeerXTipo(TipoAdjuntoEntity.PerfilProfesional).Take(5).ToList();

            return listaAdjunto.Select(p => new PerfilProfesionalDto
            {
                CodigoAdjunto = p.CodigoAdjunto,
                CodigoTipoAdjunto = p.CodigoTipoAdjunto,
                DescripcionResena = p.DescripcionResena,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionResumen = p.DescripcionResumen,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
