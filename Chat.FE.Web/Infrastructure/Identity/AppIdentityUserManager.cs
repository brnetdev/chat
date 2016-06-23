using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Infrastructure.Identity
{
    public class AppIdentityUserManager : UserManager<IdentityUser>
    {

        public AppIdentityUserManager(IUserStore<IdentityUser> store) : base(store) { }

        public static AppIdentityUserManager Create()
        {
            return new AppIdentityUserManager(new UserStore<IdentityUser>());
        }
    }
}
