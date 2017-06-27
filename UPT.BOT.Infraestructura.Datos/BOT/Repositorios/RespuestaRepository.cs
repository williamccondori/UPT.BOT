using System;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class RespuestaRepository : BaseRepository, IRespuestaRepository
    {
        private readonly BotContext contexto;

        public RespuestaRepository(BotContext contexto)
        {
            this.contexto = contexto;
        }

        public RespuestaEntity Buscar(string codigoCliente, long codigoAlternativa)
        {
            return Ejecutar(() =>
            {
                return contexto.Respuesta.FirstOrDefault(p => p.CodigoCliente == codigoCliente && p.CodigoAlternativa == codigoAlternativa);
            });
        }

        public void Crear(RespuestaEntity entidad)
        {
            Ejecutar(() =>
            {
                contexto.Respuesta.Add(entidad);
                contexto.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            throw new NotImplementedException();
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
