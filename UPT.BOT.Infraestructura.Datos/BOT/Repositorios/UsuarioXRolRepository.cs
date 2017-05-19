using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class UsuarioXRolRepository : BaseRepository, IUsuarioXRolRepository
    {
        private readonly BotContext contextoBot;

        public UsuarioXRolRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public UsuarioXRolEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.UsuarioXRol.Find(id);
            });
        }

        public void Crear(UsuarioXRolEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.UsuarioXRol.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                UsuarioXRolEntity entidad = contextoBot.UsuarioXRol.Find(id);
                contextoBot.UsuarioXRol.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<UsuarioXRolEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.UsuarioXRol.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
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
