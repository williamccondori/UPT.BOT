using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class TipoTarjetaRepository : BaseRepository, ITipoTarjetaRepository
    {
        private BotContext contexto;

        public TipoTarjetaRepository(BotContext contexto)
        {
            this.contexto = contexto;
        }

        public TipoTarjetaEntity Buscar(object id)
        {
            throw new NotImplementedException();
        }

        public void Crear(TipoTarjetaEntity entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(object id)
        {
            throw new NotImplementedException();
        }

        public IList<TipoTarjetaEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contexto.TipoTarjeta.Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                .OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
