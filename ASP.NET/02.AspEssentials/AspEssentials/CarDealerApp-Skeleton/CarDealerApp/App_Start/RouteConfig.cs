using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Customer",
                url: "{controller}/{action}/{param}",
                defaults: new { controller = "Customer", action = "All", param = UrlParameter.Optional }
            );
        }
    }
}
