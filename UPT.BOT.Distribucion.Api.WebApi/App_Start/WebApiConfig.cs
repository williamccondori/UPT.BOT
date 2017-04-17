using System.Web.Http;

namespace UPT.BOT.Distribucion.Api.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Administracion",
                routeTemplate: "api/v1/administracion/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Asistente",
                routeTemplate: "api/v1/asistente/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );
        }
    }
}
