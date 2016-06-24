using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Chat.FE.Web.Infrastructure.Identity;
using Chat.FE.Web.App_Start;


namespace Chat.FE.Web
{
    public class Global : HttpApplication
    {
        
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            using (AppIdentityDbContext db = new AppIdentityDbContext())
            {
                db.Database.Initialize(false);
            }

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocConfig.RegisterComponents();
            
            var castleControllerFactory = new Castle.Windsor.Mvc.WindsorControllerFactory(IocConfig.Container.Kernel);            
            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);

        }

        protected void Application_End()
        {
            IocConfig.ReleaseContainer();
        }
    }
}