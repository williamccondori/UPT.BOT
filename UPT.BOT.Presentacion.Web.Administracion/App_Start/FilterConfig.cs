using System.Web;
using System.Web.Mvc;

namespace UPT.BOT.Presentacion.Web.Administracion
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
