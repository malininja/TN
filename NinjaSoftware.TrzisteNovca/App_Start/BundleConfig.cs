using System.Web;
using System.Web.Optimization;

namespace NinjaSoftware.TrzisteNovca
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/jquery.ui.css",
                "~/Content/jquery.ui.theme.css",
                "~/Content/jquery.ui.datepicker.css",
                "~/Content/grid960.css",
                "~/Content/overrides.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.datepicker.hr.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/methods_hr.js",
                        "~/Scripts/messages_hr.js"));

            bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
                "~/Scripts/globalize.js",
                "~/Scripts/globalize.culture.hr.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-2.1.0.js",
                "~/Scripts/CoolJEntites.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/Scripts/NinjaSoftwareLib.js"));
        }
    }
}