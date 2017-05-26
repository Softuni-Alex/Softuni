using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC___Exercises
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
