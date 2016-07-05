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
using Microsoft.AspNet.Identity;


namespace Chat.FE.Web.Areas.Account.Controllers
{
    public class SignInController : Controller
    {
        private readonly AppIdentitySignInManager _signInManager;
        private readonly AppIdentityUserManager _userManager;

        public SignInController()
        {            
            _signInManager = System.Web.HttpContext.Current.GetOwinContext().Get<AppIdentitySignInManager>();
            _userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<AppIdentityUserManager>();            
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            UserNamePasswordVm vm = new UserNamePasswordVm();
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserNamePasswordVm vm)
        {
            if (ViewData.ModelState.IsValid)
            {

                var user = await _userManager.FindAsync(vm.Username, vm.Password);
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, true, true);
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                ViewData.ModelState.AddModelError("all", "Użytkonwik nie istnieje");
                return View(vm);

            }
            else
            {
                return View(vm);
            }

        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "SignIn", new { area = "Admin" });
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing && _userManager != null)
            {
                
            }
            base.Dispose(disposing);
        }
    }

}