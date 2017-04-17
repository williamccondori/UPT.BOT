using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Bot.Acceso.Utilidades
{
    [Serializable]
    public class AgenteApi
    {
        private readonly string gsRutaApi;
        private readonly string gsVersionApi;
        private readonly string gsServicioApi;

        public AgenteApi(string asRutaApi, string asVersionApi, string asServicioApi)
        {
            gsRutaApi = asRutaApi;
            gsVersionApi = asVersionApi;
            gsServicioApi = asServicioApi;
        }

        public RespuestaApi<T> Ejecutar<T>(
            string asResource
            , Method aoMethod = Method.GET
            , Dictionary<string, string> aoHeader = null
            , object[] aoBody = null
            , Dictionary<string, string> aoQuery = null)
            where T : class, new()
        {
            RespuestaApi<T> loResultado;

            try
            {
                string loRuta = gsRutaApi + "/" + gsVersionApi + "/" + gsServicioApi;

                IRestClient goCliente = new RestClient(loRuta);

                IRestRequest goPeticion = new RestRequest("Bot" + asResource, aoMethod)
                {
                    RequestFormat = DataFormat.Json
                };

                goPeticion.AddHeader("Content-Type", "application/json");
                goPeticion.AddHeader("Accept", "application/json");

                if (aoHeader != null)
                {
                    foreach (var loItem in aoHeader)
                    {
                        goPeticion.AddHeader(loItem.Key, loItem.Value);
                    }
                }

                if (aoBody != null)
                {
                    foreach (var loItem in aoBody)
                    {
                        goPeticion.AddBody(loItem);
                    }
                }

                if (aoQuery != null)
                {
                    foreach (var loItem in aoQuery)
                    {
                        goPeticion.AddQueryParameter(loItem.Key, loItem.Value);
                    }
                }

                var loSolicitud = goCliente.Execute<T>(goPeticion);

                if (loSolicitud.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string lsRespuesta = loSolicitud.Content;

                    var loRespuesta = JsonConvert.DeserializeObject<RespuestaApi<T>>(lsRespuesta);

                    loResultado = loRespuesta;
                }
                else
                {
                    throw new Exception(loSolicitud.ErrorMessage);
                }
            }
            catch (Exception loExcepcion)
            {
                loResultado = new RespuestaApi<T>(loExcepcion.Message, loExcepcion.StackTrace);
            }

            return loResultado;
        }
    }
}