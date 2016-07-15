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
using Microsoft.AspNet.Identity.Owin;


namespace Chat.FE.Web.Areas.Account.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppIdentityUserManager _userManager;
        private readonly AppIdentityRoleManager _roleManager;

        public AccountController()
        {
            _userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<AppIdentityUserManager>();
            _roleManager = System.Web.HttpContext.Current.GetOwinContext().Get<AppIdentityRoleManager>();
        }

        public ActionResult Index()
        {
            List<IdentityUser> users = _userManager.Users.ToList();
            return View(users);
        }
        [AllowAnonymous]
        public ActionResult AddUser()
        {
            AddUserNamePasswordVm vm = new AddUserNamePasswordVm();

            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AddUser(AddUserNamePasswordVm vm)
        {
            if (ViewData.ModelState.IsValid)
            {
                var hasher = new Microsoft.AspNet.Identity.PasswordHasher();

                IdentityUser user = new IdentityUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = vm.Login,
                    PasswordHash = hasher.HashPassword(vm.Password)
                };

                _userManager.CreateAsync(user).Wait();
                await _userManager.AddToRoleAsync(user.Id, "users");


                return RedirectToAction("Index", "Account", new { area = "Account" });
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            
            }
            base.Dispose(disposing);

        }



    }
}