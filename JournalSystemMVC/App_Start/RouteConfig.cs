using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JournalSystemMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Entries",
                url: "Entries/Page-{page}",
                defaults: new { controller = "Home", action = "Entries", page = 1 }
            );

            routes.MapRoute(
                name: "DetailsEntries",
                url: "Residents/Details/{id}/page={page}",
                defaults: new { controller = "Residents", action = "Entries", page = 1}
            );

            routes.MapRoute(
                name: "NewEntry",
                url: "Journals/NewEntry",
                defaults: new {controller = "Journals", action = "AddEntry"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
