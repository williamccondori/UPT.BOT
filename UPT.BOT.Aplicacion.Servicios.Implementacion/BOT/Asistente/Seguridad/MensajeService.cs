using System;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;
using UPT.BOT.Utilidades.Utilidades.Mensajes;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Seguridad
{
    public class MensajeService : IMensajeService
    {
        private readonly IMensajeRepository repositorioMensaje;

        public MensajeService()
        {
            repositorioMensaje = new MensajeRepository(new BotContext());
        }

        public bool Guardar(MensajeDto mensaje)
        {
            if (mensaje.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                MensajeEntity nuevoMensaje = MensajeEntity.Crear(
                    mensaje.CodigoCliente
                    , mensaje.DescripcionActividad
                    , mensaje.DescripcionCanal
                    , mensaje.DescripcionLocalidad
                    , mensaje.DescripcionServicio
                    , mensaje.DescripcionContenido
                    , mensaje.DescripcionTipoContenido
                    , mensaje.DescripcionIntencion
                    , mensaje.PorcentajeIntencion
                    , mensaje.FechaMensaje ?? DateTime.Now);

                repositorioMensaje.Crear(nuevoMensaje);
            }
            else
            {
                throw new ApplicationException(Excepcion.MetodoNoValido);
            }

            return true;
        }
    }
}
