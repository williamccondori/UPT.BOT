﻿using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Publicacion
{
    public class GaleriaProxy : BaseProxy
    {
        public GaleriaProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<bool> Eliminar(long codigoGaleria)
        {
            return Ejecutar<bool>(string.Format("galeria/{0}", codigoGaleria), Metodo.Delete);
        }

        public Response<bool> Guardar(GaleriaDto galeria)
        {
            return Ejecutar<bool>("galeria", Metodo.Post, galeria);
        }

        public Response<List<GaleriaDto>> Obtener()
        {
            return Ejecutar<List<GaleriaDto>>("galeria");
        }
    }
}
