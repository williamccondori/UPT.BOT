using System.Web;
using System.Web.Mvc;

namespace UPT.BOT.Distribucion.Api.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
