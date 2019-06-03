using System.Web;
using System.Web.Optimization;

namespace Hotel.WEB.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Areas/Admin/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Areas/Admin/Content/css/sidebar.css"));

            bundles.Add(new ScriptBundle("~/Areas/Admin/Content/js").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/bootstrap.bundle.js",
                      "~/Areas/Admin/Content/js/sidebar.js",
                      "~/Areas/Admin/Content/js/fontawesome.js"));
        }
    }
}