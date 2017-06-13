using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Encuesta
{
    public class RespuestaProxy : BaseProxy
    {
        public RespuestaProxy(string ruta) : base(ruta)
        {
        }

        public bool Guardar(RespuestasDto respuesta)
        {
            return Ejecutar<bool>("respuesta", Metodo.Post, respuesta);
        }
    }
}
