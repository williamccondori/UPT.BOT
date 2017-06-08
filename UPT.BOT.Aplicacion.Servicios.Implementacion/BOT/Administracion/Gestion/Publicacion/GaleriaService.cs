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

        public GaleriaService()
        {
            repositorioGaleria = new GaleriaRepository(contexto);
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
                /**
                GaleriaEntity galeria_ = GaleriaEntity.Crear();
                repositorioGaleria.Crear(galeria_);
                **/
            }
            else if (galeria.EstadoObjeto == EstadoObjeto.Modificado)
            {
                /**
                GaleriaEntity galeria_ = repositorioGaleria.Buscar(galeria.CodigoGaleria);
                galeria_.Modificar();
                repositorioGaleria.Modificar();
                **/
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
                Detalles = p.Detalles.Select(g => new DetalleGaleriaDto
                {
                    DescripcionTitulo = g.DescripcionTitulo,
                    DescripcionResena = g.DescripcionResena,
                    DescripcionImagen = g.DescripcionImagen,
                    CodigoDetalleGaleria = g.CodigoDetalleGaleria,
                    CodigoGaleria = g.CodigoGaleria,
                    FechaRegistro = g.FechaRegistro,
                    IndicadorEstado = g.IndicadorEstado,
                    IndicadorHabilitado = g.IndicadorHabilitado,
                    UsuarioRegistro = g.UsuarioRegistro
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
                string mensajeValidacion = null; /** PublicacionEntity.Validar(Galeria.DescripcionTitulo, Galeria.DescripcionResena
                    , Galeria.DescripcionGaleria, Galeria.DescripcionUrl); **/

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
