using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion
{
    public class NoticiaService : INoticiaService
    {
        private readonly IPublicacionRepository goPublicacionRepository;

        public NoticiaService()
        {
            goPublicacionRepository = new PublicacionRepository(new BotContext());
        }

        public IList<NoticiaConsultaDto> Consultar()
        {
            List<PublicacionEntity> listaPublicacion = goPublicacionRepository.Consultar()
                .Where(p => p.CodigoTipoPublicacion == 1)
                .OrderByDescending(p => p.FechaRegistro)
                .ToList();

            return listaPublicacion.Select(p => new NoticiaConsultaDto
            {
                CodigoPublicacion = p.CodigoPublicacion,
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionContenido = p.DescripcionContenido,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionResumen = p.DescripcionResumen,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                TipoPublicacion = null,
                EstadoObjeto = EstadoObjeto.SinCambios
            }).ToList();
        }

        public bool Guardar(NoticiaRegistroDto aoNoticia)
        {
            if (aoNoticia.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                PublicacionEntity loPublicacion = PublicacionEntity.Agregar(
                    1,
                    aoNoticia.DescripcionTitulo,
                    aoNoticia.DescripcionResumen,
                    aoNoticia.DescripcionResumen,
                    aoNoticia.DescripcionImagen,
                    aoNoticia.DescripcionUrl,
                    "WCONDORI");

                goPublicacionRepository.Crear(loPublicacion);

                return true;
            }
            else if (aoNoticia.EstadoObjeto == EstadoObjeto.Modificado)
            {
                PublicacionEntity loPublicacion = goPublicacionRepository.Buscar(aoNoticia.CodigoPublicacion);

                loPublicacion.Modificar(
                    aoNoticia.DescripcionTitulo,
                    aoNoticia.DescripcionResumen,
                    aoNoticia.DescripcionContenido,
                    aoNoticia.DescripcionImagen,
                    aoNoticia.DescripcionUrl,
                    "WCONDORI");

                goPublicacionRepository.Modificar(loPublicacion);

                return true;
            }
            else
            {
                throw new Exception("La opción seleccionada no es válida");
            }
        }

        public bool Eliminar(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
