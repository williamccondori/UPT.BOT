using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Presentacion.Web.Acceso
{
    public class BaseProxy
    {
        protected readonly string ruta;
        protected readonly string usuario;

        protected BaseProxy(string ruta, string usuario)
        {
            this.usuario = ruta;
            this.ruta = ruta;
        }

        protected RespuestaDto<T> Ejecutar<T>(string recurso, Metodo metodo = Metodo.Get, object parametro = null)
        {
            string resultado = string.Empty;

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ruta);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                cliente.DefaultRequestHeaders.Add("usuario", usuario);

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
                    case Metodo.Delete:
                        {
                            resultadoApi = cliente.DeleteAsync(ruta + recurso).Result;
                            break;
                        }
                    default: // Metodo.Get
                        {
                            resultadoApi = cliente.GetAsync(ruta + recurso).Result;
                            break;
                        }
                }

                resultado = resultadoApi.IsSuccessStatusCode ? resultadoApi.Content.ReadAsStringAsync().Result : string.Empty;
            }

            return string.IsNullOrEmpty(resultado) ? default(RespuestaDto<T>) : JsonConvert.DeserializeObject<RespuestaDto<T>>(resultado);
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
