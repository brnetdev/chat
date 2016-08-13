﻿/// <reference path="../models/room.ts" />
module app.controllers {
    export interface IRoomsController {
        getRooms(): void;
    }

    export interface IRoomsScope extends ng.IScope {
        rooms: app.models.Room[];
    }
    
    export class RoomsController implements IRoomsController {

        public static inject = ['$scope', 'roomsService'];
        constructor(private $scope: IRoomsScope, private roomsService: app.services.IRoomsService) {                        
        }

        public getRooms(): void {
            this.$scope.rooms = this.roomsService.getRooms();
        }

        private registerEvents(): void {
            this.$scope.$on(app.events.RoomsEvents.RoomAdded, (event) => {
                // tu cialo eventu

            });
        }
    }

    angular.module('app').controller('RoomsController', RoomsController);
}