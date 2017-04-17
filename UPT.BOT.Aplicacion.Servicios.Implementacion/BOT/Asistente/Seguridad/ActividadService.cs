using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Seguridad
{
    public class ActividadService : IActividadService
    {
        private readonly IActividadRepository goActividadRepository;

        public ActividadService()
        {
            goActividadRepository = new ActividadRepository(new BotContext());
        }

        public bool Guardar(ActividadDto aoActividad)
        {
            if (aoActividad.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                ActividadEntity loActividad = ActividadEntity.Crear(
                    aoActividad.DescripcionIdActividad,
                    aoActividad.DescripcionIdActividadRespuesta,
                    aoActividad.DescripcionAccion,
                    aoActividad.DescripcionIdCanal,
                    aoActividad.DescripcionLocalidad,
                    aoActividad.DescripcionUrlServicio,
                    aoActividad.DescripcionContenido,
                    aoActividad.DescripcionTipoContenido,
                    aoActividad.FechaMensaje,
                    "WCONDORI",
                    new List<ActividadCuentaEntity>
                    {
                        ActividadCuentaEntity.Crear(
                            aoActividad.Emisor.DescripcionId,
                            aoActividad.Emisor.DescripcionNombre,
                            aoActividad.Emisor.IndicadorTipo,
                            "WCONDORI"),
                        ActividadCuentaEntity.Crear(
                            aoActividad.Receptor.DescripcionId,
                            aoActividad.Receptor.DescripcionNombre,
                            aoActividad.Receptor.IndicadorTipo,
                            "WCONDORI"),
                    });

                goActividadRepository.Crear(loActividad);

                return true;
            }
            else if (aoActividad.EstadoObjeto == EstadoObjeto.Modificado)
            {
                //PublicacionEntity loPublicacion = goPublicacionRepository.Buscar(aoNoticia.CodigoPublicacion);

                //loPublicacion.Modificar(
                //    aoNoticia.DescripcionTitulo,
                //    aoNoticia.DescripcionResumen,
                //    aoNoticia.DescripcionContenido,
                //    aoNoticia.DescripcionImagen,
                //    aoNoticia.DescripcionUrl,
                //    "WCONDORI");

                //goPublicacionRepository.Modificar(loPublicacion);

                return true;
            }
            else
            {
                throw new Exception("La opción seleccionada no es válida");
            }
        }
    }
}
