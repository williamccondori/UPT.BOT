using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class PublicacionRepository : BaseRepository, IPublicacionRepository
    {
        private readonly BotContext contextoBot;

        public PublicacionRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public PublicacionEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Publicacion.Find(id);
            });
        }

        public void Crear(PublicacionEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Publicacion.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                PublicacionEntity entidad = contextoBot.Publicacion.Find(id);
                contextoBot.Publicacion.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<PublicacionEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Publicacion.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public IList<PublicacionEntity> LeerXTipo(string tipoPublicacion)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Publicacion.Where(p => p.IndicadorEstado == EstadoEntidad.Activo && p.CodigoTipoPublicacion == tipoPublicacion).OrderByDescending(p => p.FechaRegistro).ToList();
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
