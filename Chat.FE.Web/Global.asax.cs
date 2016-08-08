using Chat.Common;
using Chat.FE.Web.App_Start;
using Chat.FE.Web.Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Chat.FE.Web
{
    public class Global : HttpApplication
    {
        protected void Session_Start(object sender, EventArgs e)
        {            
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //groch z kapustą, nieporządek...i tak juz zostanie 
                                    
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());
                        
            var castleControllerFactory = new Castle.Windsor.Mvc.WindsorControllerFactory(IocConfig.Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);

            QueueManager.CreateQueues();

            //using (AppIdentityDbContext db = new AppIdentityDbContext())
            //{                
            //    db.Database.Initialize(false);
            //}

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
            }

        }

        protected void Application_End()
        {
            IocConfig.ReleaseContainer();
        }
    }
}