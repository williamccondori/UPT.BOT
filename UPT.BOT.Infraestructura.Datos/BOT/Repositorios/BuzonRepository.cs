using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class BuzonRepository : BaseRepository, IBuzonRepository
    {
        private readonly BotContext contextoBot;

        public BuzonRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public BuzonEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Buzon.Find(id);
            });
        }

        public void Crear(BuzonEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Buzon.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                BuzonEntity entidad = contextoBot.Buzon.Find(id);
                contextoBot.Buzon.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<BuzonEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Buzon.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
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
