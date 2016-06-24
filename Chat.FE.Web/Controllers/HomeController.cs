using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.FE.Web.Controllers
{
    public class HomeController : Controller
    {
        
        [Authorize]
        public ActionResult Index()
        {
            //punkt startowy aplikacji
            return View();
        }
    }
}