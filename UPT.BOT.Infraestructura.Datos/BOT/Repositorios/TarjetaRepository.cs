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
    public class TarjetaRepository : BaseRepository, ITarjetaRepository
    {
        private BotContext contexto;

        public TarjetaRepository(BotContext contexto)
        {
            this.contexto = contexto;
        }

        public TarjetaEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contexto.Tarjeta.Include(p => p.TipoTarjetaX)
                .FirstOrDefault(p => p.IndicadorEstado == EstadoEntidad.Activo && p.CodigoTarjeta == (int)id);
            });
        }

        public void Crear(TarjetaEntity entidad)
        {
            Ejecutar(() =>
            {
                contexto.Tarjeta.Add(entidad);
                contexto.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                TarjetaEntity entidad = contexto.Tarjeta.Find(id);
                contexto.Tarjeta.Remove(entidad);
                contexto.GuardarCambios();
            });
        }

        public IList<TarjetaEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contexto.Tarjeta.Include(p => p.TipoTarjetaX).Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                .OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public IList<TarjetaEntity> LeerXTipo(string codigoTipoTarjeta)
        {
            return Ejecutar(() =>
            {
                return contexto.Tarjeta.Include(p => p.TipoTarjetaX)
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo && p.CodigoTipoTarjeta == codigoTipoTarjeta)
                .OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public IList<TarjetaEntity> LeerXTipo(string codigoTipoTarjeta, int numeroRegistro)
        {
            return Ejecutar(() =>
            {
                return contexto.Tarjeta.Include(p => p.TipoTarjetaX)
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo && p.CodigoTipoTarjeta == codigoTipoTarjeta)
                .OrderByDescending(p => p.FechaRegistro).Take(numeroRegistro).ToList();
            });
        }

        public void Modificar()
        {
            Ejecutar(() =>
            {
                contexto.GuardarCambios();
            });
        }
    }
}
