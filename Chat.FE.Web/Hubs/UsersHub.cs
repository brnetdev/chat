using Chat.FE.Web.Infrastructure.Common;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Chat.FE.Web.Hubs
{
    [Authorize]
    [HubName("usersHub")]
    public class UsersHub : Hub<IUsersHubClient>
    {
        private readonly IContextDataProvider _contextDataProvider;

        public UsersHub(IContextDataProvider contextDataProvider)
        {
            _contextDataProvider = contextDataProvider;
        }

        public async Task NewUserLoggedIn(string userName)
        {
            await Clients.Others.NewUserLoggedIn(userName: userName);
        }

        public override Task OnConnected()
        {
            
            return Task.Factory.StartNew(() =>
            {


            }
            );
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return Task.Factory.StartNew(() =>
            {

            }
            );
        }
    }

    [ContractClass(typeof(IUserHubClientContract))]
    public interface IUsersHubClient
    {
        Task NewUserLoggedIn(string userName);
    }

    [ContractClassFor(typeof(IUsersHubClient))]
    public class IUserHubClientContract : IUsersHubClient
    {
        public Task NewUserLoggedIn(string userName)
        {
            Contract.Requires(!string.IsNullOrEmpty(userName));
            return default(Task);
        }
    }
}
