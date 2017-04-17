using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Bot.Acceso.Publicacion
{
    [Serializable]
    public class NoticiaProxy : BaseProxy
    {
        public NoticiaProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        public List<NoticiaConsultaBotDto> Obtener()
        {
            RespuestaApi<List<NoticiaConsultaBotDto>> loResultado = goAgente.Ejecutar<List<NoticiaConsultaBotDto>>("Noticia");

            return loResultado.Estado ? loResultado.Datos : new List<NoticiaConsultaBotDto>();
        }
    }
}

