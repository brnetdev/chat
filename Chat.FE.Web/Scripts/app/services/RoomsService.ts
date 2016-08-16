/// <reference path="../models/room.ts" />
module app.services {
    declare type roomServiceCallback = (rooms: app.models.Room[]) => void;

    export interface IRoomsService {
        roomsCallback: roomServiceCallback;
        getRooms(): void;
    }

    

    export class RoomService implements IRoomsService {
        //definiuje callback
        
        public roomsCallback: roomServiceCallback;

        public static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) {
            
        }

        getRooms(): void {
            var self = this;
            var respPromise = this.$http.get('/Chat.FE.Web/api/Rooms');
            
            respPromise.then(function (result: any) {
                console.log('Promise returns', result.data);
                self.roomsCallback(result.data);
            })
        }
    }

    angular.module('app').service('roomsService', RoomService);
}