using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class EncuestaRepository : BaseRepository, IEncuestaRepository
    {
        private readonly BotContext contextoBot;

        public EncuestaRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public EncuestaEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Encuesta.Find(id);
            });
        }

        public void Crear(EncuestaEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Encuesta.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                EncuestaEntity entidad = contextoBot.Encuesta.Find(id);
                contextoBot.Encuesta.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<EncuestaEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Encuesta
                .Include(p => p.Preguntas)
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                .OrderByDescending(p => p.FechaRegistro).ToList();
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
