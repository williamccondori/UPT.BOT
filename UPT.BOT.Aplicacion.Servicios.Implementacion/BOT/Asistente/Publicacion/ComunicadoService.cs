using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion
{
    public class ComunicadoService : BaseService, IComunicadoService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public ComunicadoService()
        {
            repositorioPublicacion = new PublicacionRepository(contexto);
        }

        public IList<ComunicadoDto> Obtener()
        {
            List<PublicacionEntity> listaPublicacion = repositorioPublicacion
                .LeerXTipo(TipoPublicacionEntity.Comunicado).Take(5).ToList();

            return listaPublicacion.Select(p => new ComunicadoDto
            {
                CodigoPublicacion = p.CodigoPublicacion,
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionResena = p.DescripcionResena,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionResumen = p.DescripcionResumen,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
