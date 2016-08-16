/// <reference path="../models/room.ts" />
module app.services {
    export interface IRoomsService {
        getRooms(): app.models.IRoom[];
    }

    export class RoomService implements IRoomsService {

        public static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) {
            
        }

        getRooms(): app.models.IRoom[] {
            var resp;
            this.$http.get('/Chat.FE.Web/api/Rooms').then(function (response) {
                resp  = <app.models.IRoom[]>response.data;
            });
            return resp;
        }
    }

    angular.module('app').service('roomsService', RoomService);
}