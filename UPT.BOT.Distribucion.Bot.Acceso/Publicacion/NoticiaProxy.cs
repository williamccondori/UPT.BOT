using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Publicacion
{
    [Serializable]
    public class NoticiaProxy : BaseProxy
    {
        public NoticiaProxy(string rutaApi) : base(rutaApi)
        {

        }

        public List<NoticiaDto> Obtener()
        {
            return Ejecutar<List<NoticiaDto>>("noticia");
        }
    }
}
