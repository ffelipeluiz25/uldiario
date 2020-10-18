using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UnidadeLotericaDiario
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "CadMegaSena",
               "cadastro-megasena",
               new { controller = "CadJogos", action = "CadMegaSena" }
           );

            routes.MapRoute(
                "PainelResultado",
                "painel-resultados",
                new { controller = "PainelResultado", action = "PainelResultado" }
            );

            routes.MapRoute(
                "PainelResultadoMobile",
                "painel-resultados-mobile",
                new { controller = "PainelResultado", action = "PainelResultadoMobile" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );



        }
    }
}
