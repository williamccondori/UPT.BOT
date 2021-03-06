﻿using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Publicacion
{
    public class ComunicadoProxy : BaseProxy
    {
        public ComunicadoProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<bool> Eliminar(long codigoPublicacion)
        {
            return Ejecutar<bool>(string.Format("comunicado/{0}", codigoPublicacion), Metodo.Delete);
        }

        public Response<bool> Guardar(ComunicadoDto comunicado)
        {
            return Ejecutar<bool>("comunicado", Metodo.Post, comunicado);
        }

        public Response<List<ComunicadoDto>> Obtener()
        {
            return Ejecutar<List<ComunicadoDto>>("comunicado");
        }
    }
}
