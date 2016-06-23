using Chat.FE.Web.Areas.Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.FE.Web.Areas.Account.Controllers
{
    public class SignInController : Controller
    {
        // GET: Account/SignIn
        public ActionResult Login()
        {
            UserNamePasswordVm vm = new UserNamePasswordVm();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(UserNamePasswordVm vm)
        {
            if(ViewData.ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return View(vm);
            }
            
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "SignIn", new { area = "Admin"});
        }

    }
}