﻿using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Publicacion
{
    [Serializable]
    public class GaleriaProxy : BaseProxy
    {
        public GaleriaProxy(string ruta) : base(ruta)
        {
        }

        public List<GaleriaDto> Obtener()
        {
            return Ejecutar<List<GaleriaDto>>("galeria");
        }
    }
}
