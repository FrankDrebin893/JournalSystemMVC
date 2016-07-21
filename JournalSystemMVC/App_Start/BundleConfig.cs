using System.Web;
using System.Web.Optimization;

namespace JournalSystemMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ajax")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js"));
            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/nv.d3.css"));

            bundles.Add(new ScriptBundle("~/bundles/nvd3scripts")
                .Include("~/Scripts/d3.min.js")
                .Include("~/Scripts/d3.js")
                .Include("~/Scripts/nv.d3.js"));

            bundles.Add(new ScriptBundle("~/bundles/reactscripts")
                .IncludeDirectory("~/Scripts/ReactScripts", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/sitescripts")
                .IncludeDirectory("~/Scripts/JQueryScripts", "*.js", true));


            bundles.Add(new ScriptBundle("~/bundles/statistics")
                .IncludeDirectory("~/Scripts/Statistics", "*.js", true));
        }
    }
}
