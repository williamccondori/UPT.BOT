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
    public class EnlaceImportanteRepository : BaseRepository, IEnlaceImportanteRepository
    {
        private readonly BotContext contexto;

        public EnlaceImportanteRepository(BotContext contexto)
        {
            this.contexto = contexto;
        }

        public EnlaceImportanteEntity Buscar(object id)
        {
            throw new NotImplementedException();
        }

        public void Crear(EnlaceImportanteEntity entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(object id)
        {
            throw new NotImplementedException();
        }

        public IList<EnlaceImportanteEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contexto.Enlace.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
