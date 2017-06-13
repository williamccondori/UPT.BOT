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
    public class RedSocialService : BaseService, IRedSocialService
    {
        private readonly IRedSocialRepository repositorioRedSocial;

        public RedSocialService()
        {
            repositorioRedSocial = new RedSocialRepository(contexto);
        }

        public List<RedSocialDto> Obtener()
        {
            List<RedSocialEntity> listaRedSocial = repositorioRedSocial.Leer().Take(5).ToList();

            return listaRedSocial.Select(p => new RedSocialDto
            {
                CodigoRedSocial = p.CodigoRedSocial,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
