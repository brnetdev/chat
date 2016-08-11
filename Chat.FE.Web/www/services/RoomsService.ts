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
            return [];
        }
    }

    angular.module('app').service('RoomService', RoomService);
}