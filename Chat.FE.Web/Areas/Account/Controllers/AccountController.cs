using Chat.FE.Web.Areas.Account.Models;
using Chat.FE.Web.Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chat.FE.Web.Areas.Account.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppIdentityUserManager _userManager;

        public AccountController()
        {            
            _userManager = this.HttpContext.GetOwinContext().Get<AppIdentityUserManager>(typeof(AppIdentityUserManager).ToString());
        }

        public ActionResult Index()
        {
            List<IdentityUser> users = _userManager.Users.ToList();
            return View(users);
        }
        
        public ActionResult AddUser()
        {
            AddUserNamePasswordVm vm = new AddUserNamePasswordVm();

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(AddUserNamePasswordVm vm)
        {
            if (ViewData.ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = vm.Login,
                    PasswordHash = Encoding.Default.GetString(System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(vm.Password)))
                };
                user.Roles.Add(new IdentityUserRole() { });
                await _userManager.CreateAsync(user);
                return RedirectToAction("Index", "Account", new { area = "Admin" });
            }
            else
            {
                return View(vm);
            }
        }

        public async Task<ActionResult> RemoveUser(string userName)
        {
            throw new NotImplementedException();
        }



    }
}