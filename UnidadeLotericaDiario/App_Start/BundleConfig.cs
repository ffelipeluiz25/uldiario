using System.Web;
using System.Web.Optimization;

namespace UnidadeLotericaDiario
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/login").Include("~/Scripts/jquery.min.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/Login/login.js"));

            bundles.Add(new ScriptBundle("~/painelresultados")
                .Include("~/Scripts/jquery.min.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/PainelResultado/painel-resultados.js"));

            bundles.Add(new ScriptBundle("~/painelresultadosmobile")
               .Include("~/Scripts/jquery.min.js",
               "~/Scripts/bootstrap.bundle.min.js",
               "~/Scripts/PainelResultado/painel-resultados-mobile.js"));

            bundles.Add(new ScriptBundle("~/cad-mega-sena")
               .Include("~/Scripts/jquery.min.js",
               "~/Scripts/bootstrap.bundle.min.js",
               "~/Scripts/CadastrosJogos/cad-mega-sena.js"));

            bundles.Add(new ScriptBundle("~/home").Include("~/Scripts/jquery.min.js",
               "~/Scripts/bootstrap.bundle.min.js", 
               "~/Scripts/home.js"));
            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}