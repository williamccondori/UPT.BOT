using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class GaleriaRepository : BaseRepository, IGaleriaRepository
    {
        private readonly BotContext contextoBot;

        public GaleriaRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public GaleriaEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Galeria.Find(id);
            });
        }

        public void Crear(GaleriaEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Galeria.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                GaleriaEntity entidad = contextoBot.Galeria.Find(id);
                contextoBot.Galeria.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<GaleriaEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Galeria.Include("DetalleGaleriaS")
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
