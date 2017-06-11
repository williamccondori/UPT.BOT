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
    public class PublicacionService : BaseService, IPublicacionService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public PublicacionService()
        {
            repositorioPublicacion = new PublicacionRepository(contexto);
        }

        public IList<PublicacionDto> Obtener()
        {
            List<PublicacionEntity> listaPublicacion = repositorioPublicacion
                .LeerXTipo(TipoPublicacionEntity.Publicacion).Take(5).ToList();

            return listaPublicacion.Select(p => new PublicacionDto
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
