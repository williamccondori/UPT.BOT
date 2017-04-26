using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly BotContext goBotContext;

        public UsuarioRepository(BotContext aoBotContext)
        {
            goBotContext = aoBotContext;
        }

        public UsuarioEntity Buscar(string asUsuario)
        {
            UsuarioEntity loUsuario = goBotContext.Usuario
                .FirstOrDefault(p => p.DescripcionUsuario == asUsuario);

            return loUsuario;
        }

        public UsuarioEntity Buscar(long algId)
        {
            UsuarioEntity loUsuario = goBotContext.Usuario.Find(algId);

            return loUsuario;
        }

        public void Crear(UsuarioEntity aoUsuario)
        {
            Ejecutar(() =>
            {
                goBotContext.Usuario.Add(aoUsuario);

                goBotContext.GuardarCambios();
            });
        }

        public void Eliminar(long algId)
        {
            Ejecutar(() =>
            {
                UsuarioEntity loUsuario = goBotContext.Usuario.Find(algId);

                goBotContext.Usuario.Remove(loUsuario);

                goBotContext.GuardarCambios();
            });
        }

        public IList<UsuarioEntity> Leer()
        {
            return Ejecutar(() =>
            {
                List<UsuarioEntity> listaUsuario = goBotContext.Usuario
                    .Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                    .ToList();

                return listaUsuario;
            });
        }

        public void Modificar(UsuarioEntity Usuario)
        {
            Ejecutar(() =>
            {
                goBotContext.GuardarCambios();
            });
        }
    }
}
