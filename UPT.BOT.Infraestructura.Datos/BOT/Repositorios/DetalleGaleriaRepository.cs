using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class DetalleGaleriaRepository : BaseRepository, IDetalleGaleriaRepository
    {
        private readonly BotContext contextoBot;

        public DetalleGaleriaRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public DetalleGaleriaEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.DetalleGaleria.Find(id);
            });
        }

        public void Crear(DetalleGaleriaEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.DetalleGaleria.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                DetalleGaleriaEntity entidad = contextoBot.DetalleGaleria.Find(id);
                contextoBot.DetalleGaleria.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<DetalleGaleriaEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.DetalleGaleria.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public void Modificar()
        {
            Ejecutar(() =>
            {
                contextoBot.GuardarCambios();
            });
        }

        public IList<DetalleGaleriaEntity> Leer(long codigoGaleria)
        {
            return Ejecutar(() =>
            {
                return contextoBot.DetalleGaleria.Where(p => p.IndicadorEstado == EstadoEntidad.Activo && p.CodigoGaleria == codigoGaleria).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }
    }
}
