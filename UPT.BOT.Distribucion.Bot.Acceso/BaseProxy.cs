using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Distribucion.Bot.Acceso
{
    [Serializable]
    public class BaseProxy
    {
        public string rutaApi;

        public BaseProxy(string rutaApi)
        {
            this.rutaApi = rutaApi;
        }

        protected T Ejecutar<T>(string recurso, Metodo metodo = Metodo.Get, object parametro = null)
        {
            string resultado = string.Empty;

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(rutaApi);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resultadoApi;

                switch (metodo)
                {
                    case Metodo.Post:
                        {
                            string json = parametro == null ? string.Empty : JsonConvert.SerializeObject(parametro);
                            resultadoApi = cliente.PostAsync(recurso, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                            break;
                        }
                    case Metodo.Put:
                        {
                            string json = parametro == null ? string.Empty : JsonConvert.SerializeObject(parametro);
                            resultadoApi = cliente.PutAsync(recurso, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                            break;
                        }
                    default:
                        {
                            resultadoApi = cliente.GetAsync(rutaApi + recurso).Result;
                            break;
                        }
                }

                if (resultadoApi.IsSuccessStatusCode)
                {
                    resultado = resultadoApi.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    resultado = string.Empty;
                }
            }

            if (string.IsNullOrEmpty(resultado))
            {
                return default(T);
            }
            else
            {
                RespuestaDto<T> respuesta = JsonConvert.DeserializeObject<RespuestaDto<T>>(resultado);

                if (respuesta.Estado)
                {
                    return respuesta.Datos;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public enum Metodo
        {
            Get,
            Post,
            Put,
            Delete
        }
    }
}
