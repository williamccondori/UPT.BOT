using System;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Adjunto
{
    [Serializable]
    public class MallaCurricularProxy : BaseProxy
    {
        public MallaCurricularProxy(string rutaApi) : base(rutaApi)
        {

        }

        public MallaCurricularDto Obtener()
        {
            return Ejecutar<MallaCurricularDto>("mallacurricular");
        }
    }
}
