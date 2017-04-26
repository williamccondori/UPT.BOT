using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class ObjetoRepository : BaseRepository, IObjetoRepository
    {
        private readonly BotContext goBotContext;

        public ObjetoRepository(BotContext aoBotContext)
        {
            goBotContext = aoBotContext;
        }

        public void Crear(ObjetoEntity aoObjeto)
        {
            Ejecutar(() =>
            {
                goBotContext.Objeto.Add(aoObjeto);

                goBotContext.GuardarCambios();
            });
        }

        public void Eliminar(long algId)
        {
            Ejecutar(() =>
            {
                ObjetoEntity loObjeto = goBotContext.Objeto.Find(algId);

                goBotContext.Objeto.Remove(loObjeto);

                goBotContext.GuardarCambios();
            });
        }

        public IList<ObjetoEntity> Leer()
        {
            return Ejecutar(() =>
            {
                List<ObjetoEntity> listaObjeto = goBotContext.Objeto
                    .Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                    .ToList();

                return listaObjeto;
            });
        }

        public void Modificar(ObjetoEntity Objeto)
        {
            Ejecutar(() =>
            {
                goBotContext.GuardarCambios();
            });
        }
    }
}
