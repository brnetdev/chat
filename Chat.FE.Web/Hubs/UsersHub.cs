using Chat.FE.Web.Infrastructure.Common;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Chat.FE.Web.Hubs
{
    [Authorize]
    [HubName("usersHub")]
    public class UsersHub : Hub
    {
        private readonly IContextDataProvider _contextDataProvider;

        public UsersHub(IContextDataProvider contextDataProvider)
        {
            _contextDataProvider = contextDataProvider;
        }

        public async Task NewUserLoggedIn(string userName)
        {
            await Clients.Others.NewUserLoggedIn(userName);
        }

        public override Task OnConnected()
        {
            return Task.Factory.StartNew(()=> {
                

                }
            );
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return Task.Factory.StartNew(() => {
                
            }
            );
        }
    }

    public interface IUsersHubClient
    {
        Task NewUserLoggedIn(string userName);
    }
}
