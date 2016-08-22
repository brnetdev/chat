using Chat.FE.Web.Infrastructure.Common;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Hubs
{
    [HubName("roomsHub")]
    public class RoomsHub : Hub
    {
        private readonly IContextDataProvider _contextDataProvider;


        public RoomsHub(IContextDataProvider contextDataProvider)
        {
            _contextDataProvider = contextDataProvider;
        }

        /// <summary>
        /// Dołączył do pokoju
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public async Task JoinRoom(string room)
        {            
            if (!string.IsNullOrEmpty(_contextDataProvider.Room))
            {
                //await disconnectRoom(_contextDataProvider.Room);
            }
            var conn = this.Context.ConnectionId;

            await this.Groups.Add(conn, room);
            _contextDataProvider.Room = room;
            await this.Clients.OthersInGroup(room).joinedToGroup(_contextDataProvider.Login);
        }

        /// <summary>
        /// Opuscil pokój
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        [HubMethodName("disconnectRoom")]
        public void DisconnectRoom(string room)
        {
            //await this.Clients.All.sayHello();               
            this.Clients.All/*OthersInGroup(room)*/.disconnectedFromGroup("asasa"/*_contextDataProvider.Login*/);
            //this.Groups.Remove(Context.ConnectionId, room);

        }

    }
}
