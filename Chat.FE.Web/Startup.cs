using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Chat.FE.Web.Infrastructure.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Owin;
using Microsoft.AspNet.SignalR.Redis;

using Chat.FE.Web.Infrastructure.SignalR;
using Chat.FE.Web.App_Start;

[assembly: OwinStartup(typeof(Chat.FE.Web.Startup))]

namespace Chat.FE.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //IoC
            IocConfig.RegisterComponents();

            //Identity
            app.CreatePerOwinContext(AppIdentityDbContext.Create);
            app.CreatePerOwinContext(AppIdentityUserManager.Create);
            app.CreatePerOwinContext<AppIdentitySignInManager>(AppIdentitySignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/SignIn/Login")
            });

            //SignalR & Redis

            GlobalHost.DependencyResolver.UseRedis(server: "localhost", port: 6379, password: "", eventKey: "Chat");
            
            app.MapSignalR(new HubConfiguration()
            {                
                EnableDetailedErrors = true,
                EnableJavaScriptProxies = true,
                Resolver = new CastleDependencyResolver(IocConfig.Container),
                //EnableJSONP = true                
            });


        }
    }
}
