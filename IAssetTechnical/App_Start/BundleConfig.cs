using System.Web;
using System.Web.Optimization;

namespace IAssetTechnical
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js"));
           
            //bundles.Add(new ScriptBundle("~/bundles/angularApp").IncludeDirectory("~/Scripts/app", "*.js", true));

           
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
