using System.Web.Mvc;
using System.Web.Routing;

namespace NEILREN
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Article",
                url: "Article/{id}",
                defaults: new { controller = "Article", action = "Read", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Album",
                url: "Album/{id}",
                defaults: new { controller = "Album", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "NEILREN", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
