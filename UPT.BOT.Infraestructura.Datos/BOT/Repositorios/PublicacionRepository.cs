using CMACT.SAD.Infraestructura.Datos.Shared;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class PublicacionRepository : BaseRepository, IPublicacionRepository
    {
        private readonly BotContext goBotContext;

        public PublicacionRepository(BotContext aoBotContext)
        {
            goBotContext = aoBotContext;
        }

        public IList<PublicacionEntity> Consultar()
        {
            return Ejecutar(() =>
            {
                List<PublicacionEntity> listaPublicacion = goBotContext.Publicacion
                    .Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                    .ToList();

                return listaPublicacion;
            });
        }

        public void Crear(PublicacionEntity aoPublicacion)
        {
            Ejecutar(() =>
            {
                goBotContext.Publicacion.Add(aoPublicacion);

                goBotContext.GuardarCambios();
            });
        }

        public void Modificar(PublicacionEntity aoPublicacion)
        {
            Ejecutar(() =>
            {
                goBotContext.GuardarCambios();
            });
        }

        public void Eliminar(long algId)
        {
            Ejecutar(() =>
            {
                PublicacionEntity loPublicacion = goBotContext.Publicacion.Find(algId);

                goBotContext.Publicacion.Remove(loPublicacion);

                goBotContext.GuardarCambios();
            });
        }

        public PublicacionEntity Buscar(long algId)
        {
            return Ejecutar(() =>
            {
                PublicacionEntity loPublicacion = goBotContext.Publicacion.Find(algId);

                return loPublicacion;
            });
        }
    }
}
