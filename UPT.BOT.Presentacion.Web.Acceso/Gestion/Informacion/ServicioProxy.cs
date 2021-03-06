﻿using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso.Gestion.Informacion
{
    public class ServicioProxy : BaseProxy
    {
        public ServicioProxy(string ruta, string usuario) : base(ruta, usuario)
        {
        }

        public Response<List<ServicioDto>> Obtener()
        {
            return Ejecutar<List<ServicioDto>>("servicio");
        }

        public Response<bool> Guardar(ServicioDto servicio)
        {
            return Ejecutar<bool>("servicio", Metodo.Post, new object[] { servicio });
        }

        public Response<bool> Eliminar(object id)
        {
            return Ejecutar<bool>(string.Format("servicio/{0}", id), Metodo.Delete);
        }
    }
}
