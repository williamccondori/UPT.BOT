using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class ObjetoRepository : BaseRepository, IObjetoRepository
    {
        private readonly BotContext contextoBot;

        public ObjetoRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public ObjetoEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Objeto.Find(id);
            });
        }

        public void Crear(ObjetoEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Objeto.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                ObjetoEntity entidad = contextoBot.Objeto.Find(id);
                contextoBot.Objeto.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<ObjetoEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Objeto.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
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
