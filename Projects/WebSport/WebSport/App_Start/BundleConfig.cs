using System.Web;
using System.Web.Optimization;

namespace WebSport
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new StyleBundle("~/bundles/bootstrap_css").Include(
                        "~/Content/bootstrap/css/bootstrap.min.css",
                        "~/Content/bootstrap/css/bootstrap.css.map"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/dist/css/AdminLTE.min.css",
                        "~/Content/dist/css/skins/_all-skins.min.css",
                        "~/Content/dist/css/personnalize.css"));

            bundles.Add(new StyleBundle("~/bundles/img").Include(
                        "~/Content/dist/img/*.png",
                        "~/Content/dist/img/*.jpg",
                        "~/Content/dist/img/*.gif",
                        "~/Content/dist/img/credit/*.png"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap_js").Include(
                        "~/Content/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/plugins/jQuery/jQuery-2.1.3.min.js",
                        "~/Content/plugins/jQueryUI/jquery-ui-1.10.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Content/dist/js/app.min.js",
                        "~/Content/dist/js/pages/dashboard.js",
                        "~/Content/dist/js/demo.js"));

        }
    }
}
