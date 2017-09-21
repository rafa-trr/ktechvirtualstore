using System.Web.Optimization;

namespace KTech.VirtualStore.Web.App_Start
{
    // http://www.asp.net/mvc/overview/performance/bundling-and-minification

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/ErroEstilo.css",
                "~/Content/Site.css"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}