using System;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Encuesta;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;
using UPT.BOT.Utilidades.Utilidades.Mensajes;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Encuesta
{
    public class RespuestaService : BaseService, IRespuestaService
    {
        private readonly IRespuestaRepository repositorioRespuesta;

        public RespuestaService()
        {
            repositorioRespuesta = new RespuestaRepository(contexto);
        }

        public bool Guardar(RespuestasDto respuesta)
        {
            if (respuesta.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                RespuestaEntity respuestaEncontrada = repositorioRespuesta.Buscar(respuesta.CodigoCliente, respuesta.CodigoAlternativa);

                if (respuestaEncontrada == null)
                {
                    RespuestaEntity nuevaRespuesta = RespuestaEntity.Crear(
                    respuesta.CodigoAlternativa,
                    respuesta.CodigoCliente,
                    string.Empty);

                    repositorioRespuesta.Crear(nuevaRespuesta);
                }
                else
                    throw new Exception("Ya has ingresado tu respuesta para esta pregunta!");
            }
            else
            {
                throw new Exception(Excepcion.MetodoNoValido);
            }

            return true;
        }
    }
}
