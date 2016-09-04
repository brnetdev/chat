using Chat.Common;
using Chat.FE.Web.App_Start;
using Chat.FE.Web.Hubs;
using Chat.FE.Web.Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Chat.FE.Web
{
    public class Global : HttpApplication
    {
        IHubContext _context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        protected void Session_Start(object sender, EventArgs e)
        {            
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //groch z kapustą, nieporządek...i tak juz zostanie 
                                                
            AreaRegistration.RegisterAllAreas();
            BundlesConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());
                                    

            var castleControllerFactory = new Castle.Windsor.Mvc.WindsorControllerFactory(IocConfig.Container.Kernel);
            var castleDependencyResolver = new Infrastructure.SignalR.CastleDependencyResolver(IocConfig.Container);

            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);
            

            //DependencyResolver.SetResolver(castleControllerFactory);

            //GlobalConfiguration.Configuration.DependencyResolver = castleDependencyResolver;
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            QueueManager.CreateQueues();           

            var roleManager = AppIdentityRoleManager.Create();
            if (!roleManager.RoleExistsAsync("users").Result)
            {
                roleManager.CreateAsync(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("users")).Wait();
            }

            if (!roleManager.RoleExistsAsync("admins").Result)
            {
                roleManager.CreateAsync(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("admins")).Wait();
            }
            var userManager = AppIdentityUserManager.Create();
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin"
                };
                userManager.CreateAsync(user).Wait();
                userManager.AddToRoleAsync(user.Id, "admin");

                Application["users"] = new List<string>();
                

            }

            

        }

        protected void Application_End()
        {
            IocConfig.ReleaseContainer();
        }

        protected void Application_PostAuthorizeRequest()
        {
            //_context.Clients.All
        }
    }
}