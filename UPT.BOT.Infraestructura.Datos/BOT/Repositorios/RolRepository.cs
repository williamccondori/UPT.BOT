using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class RolRepository : BaseRepository, IRolRepository
    {
        private readonly BotContext contextoBot;

        public RolRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public RolEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Rol.Find(id);
            });
        }

        public void Crear(RolEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Rol.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                RolEntity entidad = contextoBot.Rol.Find(id);
                contextoBot.Rol.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<RolEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Rol.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
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
