using System;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Bot.Acceso.Adjunto
{
    [Serializable]
    public class MallaCurricularProxy : BaseProxy
    {
        public MallaCurricularProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {
        }

        public AdjuntoDto Obtener()
        {
            RespuestaApi<AdjuntoDto> loResultado = goAgente.Ejecutar<AdjuntoDto>("MallaCurricular");

            return loResultado.Estado ? loResultado.Datos : new AdjuntoDto()
            {
                CodigoAdjunto = 1,
                DescripcionResumen = "",
                DescripcionTitulo = "Malla Curricular",
                TipoAdjunto = 1,
                UrlAdjunto = "http://epis.upt.edu.pe/acreditacion/img/malla_2016-I.jpg"
            };
        }
    }
}
