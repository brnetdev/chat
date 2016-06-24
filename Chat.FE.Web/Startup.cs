using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Chat.FE.Web.Infrastructure.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Chat.FE.Web.Startup))]

namespace Chat.FE.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(AppIdentityDbContext.Create);
            app.CreatePerOwinContext<AppIdentityUserManager>(AppIdentityUserManager.Create);
            app.CreatePerOwinContext<AppIdentitySignInManager>(AppIdentitySignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/SignIn/Login")
            });
        }
    }
}
