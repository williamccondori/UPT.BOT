using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly BotContext contextoBot;

        public UsuarioRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public UsuarioEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Usuario.Find(id);
            });
        }

        public void Crear(UsuarioEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Usuario.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                UsuarioEntity entidad = contextoBot.Usuario.Find(id);
                contextoBot.Usuario.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<UsuarioEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Usuario.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public void Modificar()
        {
            Ejecutar(() =>
            {
                contextoBot.GuardarCambios();
            });
        }

        public bool Verificar(string usuario, string password)
        {
            return contextoBot.Usuario.Any(p => p.IndicadorEstado == EstadoEntidad.Activo && p.DescripcionUsuario == usuario && p.DescripcionPassword == password);
        }
    }
}
