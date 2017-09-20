using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KTech.VirtualStore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // /

            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { Controller = "Vitrine", Action = "ListaProdutos", categoria = (string)null, pagina = 1 }
                );

            // /Pagina

            routes.MapRoute(
                name: null,
                url: "Pagina{pagina}",
                defaults: new { Controller = "Vitrine", Action = "ListaProdutos", categoria = (string)null },
                constraints: new { pagina = @"\d+" }
                );

            // /Categoria

            routes.MapRoute(
                name: null,
                url: "{categoria}",
                defaults: new { Controller = "Vitrine", Action = "ListaProdutos", pagina = 1 }
                );

            // /Categoria/Pagina

            routes.MapRoute(
                name: null,
                url: "{categoria}/Pagina{pagina}",
                defaults: new { Controller = "Vitrine", Action = "ListaProdutos" },
                constraints: new { pagina = @"\d+" }
                );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}"
                );
        }
    }
}
