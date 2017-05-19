using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class TipoBuzonRepository : BaseRepository, ITipoBuzonRepository
    {
        private readonly BotContext contextoBot;

        public TipoBuzonRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public TipoBuzonEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.TipoBuzon.Find(id);
            });
        }

        public void Crear(TipoBuzonEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.TipoBuzon.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                TipoBuzonEntity entidad = contextoBot.TipoBuzon.Find(id);
                contextoBot.TipoBuzon.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<TipoBuzonEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.TipoBuzon.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public void Modificar()
        {
            Ejecutar(() =>
            {
                contextoBot.GuardarCambios();
            });
        }
    }
}
