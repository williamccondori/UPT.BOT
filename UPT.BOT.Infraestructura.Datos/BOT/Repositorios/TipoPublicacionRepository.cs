using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class TipoPublicacionRepository : BaseRepository, ITipoPublicacionRepository
    {
        private readonly BotContext contextoBot;

        public TipoPublicacionRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public TipoPublicacionEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.TipoPublicacion.Find(id);
            });
        }

        public void Crear(TipoPublicacionEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.TipoPublicacion.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                TipoPublicacionEntity entidad = contextoBot.TipoPublicacion.Find(id);
                contextoBot.TipoPublicacion.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<TipoPublicacionEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.TipoPublicacion.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
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
