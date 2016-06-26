using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Infrastructure.Identity
{
    public class AppIdentityRoleManager : RoleManager<IdentityRole>
    {
        public AppIdentityRoleManager(RoleStore<IdentityRole> store) : base(store)
        {

        }

        public static AppIdentityRoleManager Create()
        {
            return new AppIdentityRoleManager(new RoleStore<IdentityRole>());
        }
    }
}
