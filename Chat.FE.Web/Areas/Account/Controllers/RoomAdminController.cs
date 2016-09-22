using Chat.BE.Data;
using Chat.BE.Data.Entities;
using Chat.FE.Web.Areas.Account.Models;
using Chat.FE.Web.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chat.FE.Web.Areas.Account.Controllers
{
    [System.Web.Mvc.Authorize]
    public class RoomAdminController : Controller
    {
    
        public ActionResult Add()
        {
            AddRoomVM vm = new AddRoomVM();
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddRoomVM room)
        {
            if(this.ModelState.IsValid)
            {
                using (Db db = new Db())
                {
                    await Task.Factory.StartNew(() =>
                    {
                        var roomEntity = new Room { Description = room.Description, Title = room.Title };
                        db.Rooms.Add(roomEntity);
                    });                                        
                }

                var roomHub = GlobalHost.ConnectionManager.GetHubContext<RoomsHub>();
                await roomHub.Clients.All.RoomAdded();

                return RedirectToAction(actionName: "Add", controllerName: "Account", routeValues: new { area = "Account" });
            }
            return View(room);
        }

        [HttpPost]
        public async Task<JsonResult> CheckUniqueRoom(string Title)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (Db db = new Db())
                {
                    return Json(db.Rooms.Count(p => p.Title == Title) == 0);
                }
            });
        }
    }
}