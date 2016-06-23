using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Infrastructure.Identity
{
    public class AppIdentitySignInManager : SignInManager<IdentityUser, string>
    {
        public AppIdentitySignInManager(AppIdentityUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        { }

        public static AppIdentitySignInManager Create(IdentityFactoryOptions<AppIdentitySignInManager> options, IOwinContext context)
        {
            return new AppIdentitySignInManager(context.GetUserManager<AppIdentityUserManager>(), context.Authentication);
        }
    }
}
