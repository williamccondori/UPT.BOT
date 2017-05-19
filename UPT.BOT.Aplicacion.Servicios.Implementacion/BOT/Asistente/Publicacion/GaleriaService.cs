using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion
{
    public class GaleriaService : BaseService, IGaleriaService
    {
        private readonly IGaleriaRepository repositorioGaleria;
        private readonly IDetalleGaleriaRepository repositorioDetalleGaleria;

        public GaleriaService()
        {
            BotContext contexto = new BotContext();
            repositorioGaleria = new GaleriaRepository(contexto);
            repositorioDetalleGaleria = new DetalleGaleriaRepository(contexto);
        }

        public IList<GaleriaDto> Obtener()
        {
            IEnumerable<GaleriaEntity> listaGaleria = repositorioGaleria.Leer().Take(5);

            return listaGaleria.Select(p => new GaleriaDto
            {
                CodigoGaleria = p.CodigoGaleria,
                DescripcionResena = p.DescripcionResena,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }

        public IList<DetalleGaleriaDto> ObtenerDetalle(long codigoGaleria)
        {
            IEnumerable<DetalleGaleriaEntity> listaDetalleGaleria = repositorioDetalleGaleria.Leer(codigoGaleria).Where(p => p.IndicadorHabilitado == Indicador.Si).Take(5);

            return listaDetalleGaleria.Select(p => new DetalleGaleriaDto
            {
                CodigoGaleria = p.CodigoGaleria,
                DescripcionResena = p.DescripcionResena,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionTitulo = p.DescripcionTitulo,
                CodigoDetalleGaleria = p.CodigoDetalleGaleria,
                IndicadorHabilitado = p.IndicadorHabilitado
            }).ToList();
        }
    }
}
