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
            this.Clients.Group(groupName: room).NewMessageRecived(message: message, sender: _contextDataProvider.Login);
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
        void NewMessageRecived(string message, string sender);

    }

    [ContractClassFor(typeof(IChatHubClient))]
    public class ChatHubClientContractClass : IChatHubClient
    {
        public void NewMessageRecived(string message, string sender)
        {
            Contract.Requires(!string.IsNullOrEmpty(sender));
        }
    }

}
