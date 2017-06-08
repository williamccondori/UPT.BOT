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
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ruta);
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
                                resultadoApi = cliente.GetAsync(ruta + recurso).Result;
                                break;
                            }
                    }

                    if (resultadoApi.IsSuccessStatusCode)
                    {
                        string resultado = resultadoApi.IsSuccessStatusCode ? resultadoApi.Content.ReadAsStringAsync().Result : string.Empty;

                        if (string.IsNullOrEmpty(resultado))
                            throw new Exception("No se obtuvo resultados de la consulta.");

                        return JsonConvert.DeserializeObject<RespuestaDto<T>>(resultado);
                    }
                    else
                    {
                        string error = resultadoApi.ReasonPhrase;

                        throw new Exception(error);
                    }
                }
            }
            catch (Exception excepcion)
            {
                return new RespuestaDto<T>(excepcion.Message, excepcion.StackTrace);
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
