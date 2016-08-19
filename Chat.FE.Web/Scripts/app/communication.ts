/// <reference path="../typings/signalr/signalr-1.0.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

interface IRoomHubProxy {
    client: IRoomClient;
    server: IRoomServer;
}

interface SignalR {
    roomProxy: IRoomHubProxy
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





