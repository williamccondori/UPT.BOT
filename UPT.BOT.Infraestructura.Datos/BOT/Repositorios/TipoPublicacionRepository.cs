using CMACT.SAD.Infraestructura.Datos.Shared;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class TipoPublicacionRepository : BaseRepository, ITipoPublicacionRepository
    {
        private readonly BotContext goBotContext;

        public TipoPublicacionRepository(BotContext aoBotContext)
        {
            goBotContext = aoBotContext;
        }

        public IList<TipoPublicacionEntity> Consultar()
        {
            return Ejecutar(() =>
            {
                List<TipoPublicacionEntity> listaTipoPublicacion = goBotContext.TipoPublicacion
                    .Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                    .ToList();

                return listaTipoPublicacion;
            });
        }

        public void Agregar(TipoPublicacionEntity aoTipoPublicacion)
        {
            Ejecutar(() =>
            {
                goBotContext.TipoPublicacion.Add(aoTipoPublicacion);

                goBotContext.GuardarCambios();
            });
        }

        public void Modificar(TipoPublicacionEntity aoTipoPublicacion)
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
                TipoPublicacionEntity loTipoPublicacion = goBotContext.TipoPublicacion.Find(algId);

                goBotContext.TipoPublicacion.Remove(loTipoPublicacion);

                goBotContext.GuardarCambios();
            });
        }

        public TipoPublicacionEntity Buscar(long algId)
        {
            return Ejecutar(() =>
            {
                TipoPublicacionEntity loTipoPublicacion = goBotContext.TipoPublicacion.Find(algId);

                return loTipoPublicacion;
            });
        }
    }
}
