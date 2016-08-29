/// <reference path="../models/room.ts" />
/// <reference path="basecontroller.ts" />
/// <reference path="../communication.ts" />
/// <reference path="../../typings/signalr/signalr-1.0.d.ts" />
module app.controllers {
    
    export interface IRoomsController {
        getRooms(): void;
        joinRoom(room: app.models.IRoom): void;
        joinedToRoom(room: string, login: string): void;
        updateCallerRoomStatus(room: string): void;
    }

    export interface IRoomsScope extends ng.IScope {
        rooms: app.models.Room[];
        name: string;
        sendMessage(): void;
        joinRoom(room: app.models.IRoom): void;

    }
    
    export class RoomsController extends BaseController implements IRoomsController {
        private _roomProxy: IRoomHubProxy;        
        public static $inject = ['$scope', 'roomsService'];
        constructor(private $scope: IRoomsScope, private roomsService: app.services.IRoomsService) {                                
            super();
            this._roomProxy = $.connection.roomsHub;
            var self = this;            
            
            this.registerEvents();
            this.$scope.rooms = app.models.Room[1];
            var rooms = this.getRooms();            
            this.$scope.name = "Piotr";
            self._roomProxy.client.disconnectedFromGroup = (login: string) => this.disconnectedFromGroup(login);
            self._roomProxy.client.joinedToRoom = (room, login) => this.joinedToRoom(room, login);

            //inicjalizacja scope
            this.$scope.sendMessage = () => this.sendMessage();
            this.$scope.joinRoom = (room) => this.joinRoom(room);


            this.$scope.$on('$destroy', function () { console.log('Destroying RoomsContreller') });
        }

        public getRooms(): void {
            var self = this;
            this.roomsService.roomsCallback = function (rooms: app.models.Room[]) {                                            
                self.$scope.rooms = rooms;                
            }
            this.roomsService.getRooms();            
        }

        public joinRoom(room: app.models.Room): void {
            debugger;
            this._roomProxy.server.joinRoom(room.Name);            
        }

        public sendMessage() {
            debugger;
            this._roomProxy.server.disconnectRoom('pokoj');
        }

        public setRooms(rooms: app.models.Room[]) {
            this.$scope.rooms = rooms;
        }

        public registerEvents(): void {
            this.$scope.$on(app.events.RoomsEvents.RoomAdded, (event) => {                
                this.getRooms();
            });
        }

        public disconnectedFromGroup(login: string) {            
            alert(login);
        }

        public joinedToRoom(room: string, login: string): void {
            this.$scope.$emit(app.events.RoomsEvents.RoomChanged, login, room);
        }

        public updateCallerRoomStatus(room: string): void {
            this.$scope.$emit(app.events.RoomsEvents.RoomStatusUpdated, room);
        }

    }

    angular.module('app').controller('RoomsController', RoomsController);
}