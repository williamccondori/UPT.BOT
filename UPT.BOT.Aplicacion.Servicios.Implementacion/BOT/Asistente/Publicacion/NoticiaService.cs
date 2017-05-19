using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion
{
    public class NoticiaService : INoticiaService
    {
        private readonly IPublicacionRepository repositorioPublicacion;

        public NoticiaService()
        {
            repositorioPublicacion = new PublicacionRepository(new BotContext());
        }

        public IList<NoticiaDto> Obtener()
        {
            IEnumerable<PublicacionEntity> listaPublicacion = repositorioPublicacion.LeerXTipo(TipoPublicacionEntity.Noticia).Take(5);

            return listaPublicacion.Select(p => new NoticiaDto
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
