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


            bundles.Add(new ScriptBundle("~/Scripts/appBundle").Include("~/Scripts/app/app.js"));
                        
            bundles.Add(new ScriptBundle("~/Scripts/communication").Include(
               "~/Scripts/app/communication.js"               
               ));

            bundles.Add(new ScriptBundle("~/Scripts/models").Include(
                "~/Scripts/app/models/Room.js",
                "~/Scripts/app/models/User.js"
                ));
            bundles.Add(new ScriptBundle("~/Scripts/services").Include(
                "~/Scripts/app/services/RoomsService.js",
                "~/Scripts/app/services/UsersService.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/events").Include(
                "~/Scripts/app/events/Events.js"                
                ));

            bundles.Add(new ScriptBundle("~/Scripts/controllers").Include(
                "~/Scripts/app/controllers/BaseController.js",
                "~/Scripts/app/controllers/MainController.js",
                "~/Scripts/app/controllers/UsersController.js",
                "~/Scripts/app/controllers/RoomsController.js",
                "~/Scripts/app/controllers/ChatController.js"
                ));

            BundleTable.EnableOptimizations = false;



            
        }


    }
}
