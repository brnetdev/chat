using Chat.FE.Web.Infrastructure.Common;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Hubs
{

    public class ChatHub : Hub<IChatHubClient>
    {
        private IContextDataProvider _contextDataProvider;

        public ChatHub(IContextDataProvider contextDataProvider)
        {
            _contextDataProvider = contextDataProvider;
        }

        public void BroadcastMessage(string message, string room)
        {
            if (string.IsNullOrEmpty(room))
            {                
                this.Clients.Others.NewMessageRecived(message: message, sender: _contextDataProvider.Login);
                this.Clients.Caller.NewMessageRecived(message: message, sender: "Ty:");
            }
            else
            {
                this.Clients.OthersInGroup(groupName: room).NewMessageRecived(message: message, sender: _contextDataProvider.Login);
                this.Clients.Caller.NewMessageRecived(message: message, sender: "Ty:");
            }
        }
    }
    
    /// <summary>
    /// Interfejs kliencki do komunikacji push okna chat
    /// </summary>
    [ContractClass(typeof(ChatHubClientContractClass))]
    public interface IChatHubClient
    {
        /// <summary>
        /// Wysyła informacje o nowej wiadomości do klientów
        /// </summary>
        /// <param name="message">Wiadomość</param>
        /// <param name="sender">Login wysyłającego</param>
        Task NewMessageRecived(string message, string sender);

    }

    [ContractClassFor(typeof(IChatHubClient))]
    public class ChatHubClientContractClass : IChatHubClient
    {
        public Task NewMessageRecived(string message, string sender)
        {
            Contract.Requires(!string.IsNullOrEmpty(sender));
            return default(Task);
        }
    }

}
