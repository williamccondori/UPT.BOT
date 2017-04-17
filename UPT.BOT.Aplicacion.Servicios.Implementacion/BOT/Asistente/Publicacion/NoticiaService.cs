using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion
{
    public class NoticiaService : INoticiaService
    {
        private readonly IPublicacionRepository goPublicacionRepository;

        public NoticiaService()
        {
            goPublicacionRepository = new PublicacionRepository(new BotContext());
        }

        public IList<NoticiaConsultaBotDto> Consultar()
        {
            List<PublicacionEntity> listaPublicacion = goPublicacionRepository.Consultar()
                .Where(p => p.CodigoTipoPublicacion == 1)
                .OrderByDescending(p => p.FechaRegistro)
                .Take(5)
                .ToList();

            return listaPublicacion.Select(p => new NoticiaConsultaBotDto
            {
                CodigoPublicacion = p.CodigoPublicacion,
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionContenido = p.DescripcionContenido,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionResumen = p.DescripcionResumen,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
