/// <reference path="../models/room.ts" />
module app.services {
    export interface IRoomsService {
        roomServiceCallback: (rooms: app.models.Room[]) => void;
        getRooms(): void;
    }

    export class RoomService implements IRoomsService {
        //definiuje callback

        public roomServiceCallback: (rooms: app.models.Room[]) => void;

        public static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) {
            
        }

        getRooms(): void {
                        
            var respPromise = this.$http.get('/Chat.FE.Web/api/Rooms');

            respPromise.then(function(result: app.models.IRoom[]) {
                this.roomServiceCallback(<app.models.IRoom[]>result);
            })
        }
    }

    angular.module('app').service('roomsService', RoomService);
}