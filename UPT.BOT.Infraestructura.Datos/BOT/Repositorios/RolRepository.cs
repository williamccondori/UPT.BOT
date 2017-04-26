using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class RolRepository : BaseRepository, IRolRepository
    {
        private readonly BotContext goBotContext;

        public RolRepository(BotContext aoBotContext)
        {
            goBotContext = aoBotContext;
        }

        public void Crear(RolEntity aoRol)
        {
            Ejecutar(() =>
            {
                goBotContext.Rol.Add(aoRol);

                goBotContext.GuardarCambios();
            });
        }

        public void Eliminar(long algId)
        {
            Ejecutar(() =>
            {
                RolEntity loRol = goBotContext.Rol.Find(algId);

                goBotContext.Rol.Remove(loRol);

                goBotContext.GuardarCambios();
            });
        }

        public IList<RolEntity> Leer()
        {
            return Ejecutar(() =>
            {
                List<RolEntity> listaRol = goBotContext.Rol
                    .Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                    .ToList();

                return listaRol;
            });
        }

        public void Modificar(RolEntity Rol)
        {
            Ejecutar(() =>
            {
                goBotContext.GuardarCambios();
            });
        }

        public RolEntity Buscar(long algId)
        {
            return Ejecutar(() =>
            {
                RolEntity loRol = goBotContext.Rol.Find(algId);

                return loRol;
            });
        }
    }
}
