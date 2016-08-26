/// <reference path="../typings/signalr/signalr-1.0.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

interface IRoomHubProxy {
    client: IRoomClient;
    server: IRoomServer;
}

interface IRoomServer {
    joinRoom(room: string): void;
    disconnectRoom(room: string): void;
}

interface IRoomClient {
    joinedToGroup(login: string): void;
    disconnectedFromGroup(login: string): void;
    roomAdded(): void;
    roomDeleted(): void;
    roomModified(): void;
}


interface IUsersHubProxy {
    client: IUsersClient;
    server: IUsersServer;
}

interface IUsersClient {
    newUsersLoggedIn(userName: string): void;
}

interface IUsersServer {
    newUsersLoggedIn(userName: string): void;
}

interface IChatHubProxy {
    client: IChatClient;
    server: IChatServer;
}

interface IChatClient {
    newMessageRecived(message: string, login: string): void;
}

interface IChatServer {
    broadcastMessage(message: string, room: string): void;
}

interface SignalR {
    roomsHub: IRoomHubProxy;
    usersHub: IUsersHubProxy;
    chatHub: IChatHubProxy;
}





