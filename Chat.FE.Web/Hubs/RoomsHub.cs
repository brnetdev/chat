using Chat.FE.Web.Infrastructure.Common;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using System;
using System.Diagnostics.Contracts;

namespace Chat.FE.Web.Hubs
{
    [HubName("roomsHub")]
    [Authorize]
    public class RoomsHub : Hub<IRoomHubClient>
    {
        private readonly IContextDataProvider _contextDataProvider;
        
        public RoomsHub(IContextDataProvider contextDataProvider)
        {
            _contextDataProvider = contextDataProvider;
        }

        [HubMethodName("joinRoom")]       
        public async Task JoinRoom(string room)
        {
            try
            {
                if (!string.IsNullOrEmpty(_contextDataProvider.Room))
                {
                   await this.DisconnectRoom(_contextDataProvider.Room);
                }
                var conn = this.Context.ConnectionId;

                await this.Groups.Add(conn, room);
                _contextDataProvider.Room = room;                
                //informuje innych, że odłączył się od grupy
                await this.Clients.OthersInGroup(room).JoinedToRoom(_contextDataProvider.Login, room);
                //aktualizuje swój status
                await this.Clients.Caller.UpdateCallerRoomStatus(room);
            }
            catch
            {
                throw new HubException("Nie udało się połączyć do pokoju");
            }
        }
                
        [HubMethodName("disconnectRoom")]
        public async Task DisconnectRoom(string room)
        {            
            await this.Clients.OthersInGroup(room).DisconnectedFromRoom(_contextDataProvider.Login, room);
        }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(_contextDataProvider != null);
            Contract.Invariant(!string.IsNullOrEmpty(_contextDataProvider.Login));
        }

    }
    
    /// <summary>
    /// Silne typowanie hub - strona kliencka
    /// </summary>
    [ContractClass(typeof(RoomHubClientContract))]
    public interface IRoomHubClient
    {
        /// <summary>
        /// Zdarzenie informujuące o dołączeniu użytkownika do pokoju
        /// </summary>
        /// <param name="login">Login użytkownika</param>
        /// <param name="room">Pokój do którego dołączył</param>
        /// <returns></returns>
        Task JoinedToRoom(string login, string room);
        Task DisconnectedFromRoom(string login, string room);

        Task UpdateCallerRoomStatus(string room);

        Task RoomAdded();
        Task RoomDeleted();
        Task RoomModified();
    }

    [ContractClassFor(typeof(IRoomHubClient))]
    public class RoomHubClientContract : IRoomHubClient
    {
        public Task DisconnectedFromRoom(string login, string room)
        {
            Contract.Requires(!string.IsNullOrEmpty(login));
            return default(Task);
        }

        public Task JoinedToRoom(string login, string room)
        {
            Contract.Requires(!string.IsNullOrEmpty(login));
            return default(Task);
        }

        public Task RoomAdded()
        {
            return default(Task);
        }

        public Task RoomDeleted()
        {
            return default(Task);
        }

        public Task RoomModified()
        {
            return default(Task);
        }

        public Task UpdateCallerRoomStatus(string room)
        {
            return default(Task);
        }
    }
}
