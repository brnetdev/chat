using System.Web.Optimization;

namespace Chat.FE.Web.App_Start
{
    public static class BundlesConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.*",
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Boostrap").Include(
                "~/Scripts/Bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/www/app.js"));
            bundles.Add(new ScriptBundle("~/bundles/test").Include("~/www/test.js"));
            bundles.Add(new ScriptBundle("~/bundles/models").Include(
                "~/www/models/Room.js",
                "~/www/models/User.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                "~/www/services/RoomsService.js",
                "~/www/services/UsersService.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                "~/www/controllers/BaseController.js",
                "~/www/controllers/MainController.js",
                "~/www/controllers/UsersController.js",
                "~/www/controllers/RoomsController.js",
                "~/www/controllers/ChatController.js"
                ));

            BundleTable.EnableOptimizations = false;



            
        }


    }
}
