using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Publicacion
{
    public class GaleriaService : BaseService, IGaleriaService
    {
        private readonly IGaleriaRepository repositorioGaleria;
        private readonly IDetalleGaleriaRepository repositorioDetalleGaleria;

        public GaleriaService()
        {
            repositorioGaleria = new GaleriaRepository(contexto);
            repositorioDetalleGaleria = new DetalleGaleriaRepository(contexto);
        }

        public bool Eliminar(object id)
        {
            repositorioGaleria.Eliminar(id);
            return true;
        }

        public bool Guardar(GaleriaDto galeria)
        {
            Validar(galeria);

            if (galeria.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                List<DetalleGaleriaEntity> detalles = galeria.Detalles.Where(p => p.IndicadorEstado == "A" && p.EstadoObjeto == EstadoObjeto.Nuevo)
                    .Select(p => DetalleGaleriaEntity.Crear(galeria.CodigoGaleria, p.DescripcionTitulo, p.DescripcionImagen, p.DescripcionResena
                    , galeria.UsuarioRegistro)).ToList();

                GaleriaEntity galeria_ = GaleriaEntity.Crear(galeria.DescripcionTitulo, galeria.DescripcionImagen
                    , galeria.DescripcionResena, galeria.DescripcionUrl, detalles, galeria.UsuarioRegistro);

                repositorioGaleria.Crear(galeria_);
            }
            else if (galeria.EstadoObjeto == EstadoObjeto.Modificado)
            {
                GaleriaEntity galeria_ = repositorioGaleria.Buscar(galeria.CodigoGaleria);
                galeria_.Modificar(galeria.DescripcionTitulo, galeria.DescripcionImagen
                    , galeria.DescripcionResena, galeria.DescripcionUrl, galeria.IndicadorEstado, galeria.UsuarioRegistro);
                repositorioGaleria.Modificar();

                foreach (var detalle in galeria.Detalles)
                    if(detalle.EstadoObjeto == EstadoObjeto.Nuevo)
                    {
                        DetalleGaleriaEntity detalleGaleriaEntidad = DetalleGaleriaEntity.Crear(galeria.CodigoGaleria, detalle.DescripcionTitulo, detalle.DescripcionImagen
                            , detalle.DescripcionResena, galeria.UsuarioRegistro);

                        repositorioDetalleGaleria.Crear(detalleGaleriaEntidad);
                    }
                    else if(detalle.EstadoObjeto == EstadoObjeto.Borrado)
                        repositorioDetalleGaleria.Eliminar(detalle.CodigoDetalleGaleria);
                         
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<GaleriaDto> Obtener()
        {
            List<GaleriaEntity> galerias = repositorioGaleria.Leer().ToList();

            List<GaleriaDto> galerias_ = galerias.Select(p => new GaleriaDto
            {
                CodigoGaleria = p.CodigoGaleria,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                Detalles = p.DetalleGaleriaS.Where(g =>g.IndicadorEstado == "A").Select(g => new DetalleGaleriaDto
                {
                    DescripcionTitulo = g.DescripcionTitulo,
                    DescripcionResena = g.DescripcionResena,
                    DescripcionImagen = g.DescripcionImagen,
                    CodigoDetalleGaleria = g.CodigoDetalleGaleria,
                    CodigoGaleria = g.CodigoGaleria,
                    FechaRegistro = g.FechaRegistro,
                    IndicadorEstado = g.IndicadorEstado,
                    IndicadorHabilitado = g.IndicadorHabilitado,
                    UsuarioRegistro = g.UsuarioRegistro,
                    IndicadorMostrar = true
                }).ToList(),
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return galerias_;
        }

        private void Validar(GaleriaDto galeria)
        {
            StringBuilder mensaje = new StringBuilder();

            if (galeria == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = GaleriaEntity.Validar(galeria.DescripcionImagen); 

                mensaje.Append(mensajeValidacion);
            }

            if (mensaje.Length > 0)
            {
                StringBuilder validacion = new StringBuilder();
                validacion.Append("Validaciones: ");
                validacion.Append(mensaje.ToString());
                throw new Exception(validacion.ToString());
            }
        }
    }
}
