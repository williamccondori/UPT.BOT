using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Publicacion
{
    [Serializable]
    public class PublicacionProxy : BaseProxy
    {
        public PublicacionProxy(string ruta) : base(ruta)
        {
        }

        public List<PublicacionDto> Obtener()
        {
            return Ejecutar<List<PublicacionDto>>("publicacion");
        }
    }
}
