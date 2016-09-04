using Chat.FE.Web.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.FE.Web.Controllers
{
    public class HomeController : Controller
    {
                
        [System.Web.Mvc.Authorize]
        public ActionResult Index()
        {
            //punkt startowy aplikacji
            if (this.HttpContext.Application["users"] == null)
            {
                this.HttpContext.Application["users"] = new List<string>();

            }
            var loginName = System.Web.HttpContext.Current.User.Identity.Name;
            if (!((List<string>)this.HttpContext.Application["users"]).Contains(loginName))
            {
                ((List<string>)this.HttpContext.Application["users"]).Add(System.Web.HttpContext.Current.User.Identity.Name);               
                
            }
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<UsersHub>();
            hubContext.Clients.All.NewUserLoggedIn(System.Web.HttpContext.Current.User.Identity.Name);

            return View();
        }
    }
}