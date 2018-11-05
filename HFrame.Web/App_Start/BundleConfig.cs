using System.Web;
using System.Web.Optimization;

namespace HFrame.Web
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            ///Js
            bundles.Add(new ScriptBundle("~/Bootstrap").Include(
                "~/Content/Plugin/bootstrap/js/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/Jquery").Include(
                "~/Content/Plugin/Jquery/Jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Common").Include(
                "~/Content/common.js"));
            ///Css
            bundles.Add(new StyleBundle("~/Bootstrap").Include(
            "~/Content/Plugin/bootstrap/css/bootstrap.css"));
            //BundleTable.EnableOptimizations = true;
        }
    }
}
