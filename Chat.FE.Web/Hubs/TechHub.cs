using Chat.FE.Web.Infrastructure.Common;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Hubs
{
    /// <summary>
    /// Zmiany statusu - typu wylogowanie, zalogowanie, statusy techniczne
    /// </summary>
    public class TechHub : Hub
    {
        private readonly IContextDataProvider _contextDataProvider;
                

        public TechHub(IContextDataProvider contextDataProvider)
        {
            _contextDataProvider = contextDataProvider;
        }

        /// <summary>
        /// Dołączył do pokoju
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public async Task JoinGroup(string group)
        {            
            if (!string.IsNullOrEmpty(_contextDataProvider.Room))
            {
                await DisconnectGroup(_contextDataProvider.Room);
            }
            var conn = this.Context.ConnectionId;

            await this.Groups.Add(conn, group);            
            await this.Clients.OthersInGroup(group).joinedToGroup(_contextDataProvider.Login);
        }

        /// <summary>
        /// Opuscil pokój
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public async Task DisconnectGroup(string group)
        {
            await this.Clients.OthersInGroup(group).disconnectedFromGroup(_contextDataProvider.Login);
            await this.Groups.Remove(Context.ConnectionId, group);

        }
    }
}
