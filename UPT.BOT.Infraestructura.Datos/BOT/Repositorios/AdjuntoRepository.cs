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
    public class AdjuntoRepository : BaseRepository, IAdjuntoRepository
    {
        private readonly BotContext contextoBot;

        public AdjuntoRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public AdjuntoEntity Buscar(object id)
        {
            throw new NotImplementedException();
        }

        public void Crear(AdjuntoEntity entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(object id)
        {
            throw new NotImplementedException();
        }

        public IList<AdjuntoEntity> Leer()
        {
            throw new NotImplementedException();
        }

        public IList<AdjuntoEntity> LeerXTipo(string tipoAdjunto)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Adjunto.Where(p => p.IndicadorEstado == EstadoEntidad.Activo && p.CodigoTipoAdjunto == tipoAdjunto).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
