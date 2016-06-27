using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Hubs
{

    public class ChatHub : Hub
    {
        public void BroadcastMessage(string message)
        {
            //this.Clients.Group()
        }
    }
}
