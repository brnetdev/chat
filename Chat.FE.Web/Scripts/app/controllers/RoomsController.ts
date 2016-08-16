/// <reference path="../models/room.ts" />
/// <reference path="basecontroller.ts" />
module app.controllers {
    export interface IRoomsController {
        getRooms(): void;
    }

    export interface IRoomsScope extends ng.IScope {
        rooms: app.models.Room[];
    }
    
    export class RoomsController extends BaseController implements IRoomsController {

        public static $inject = ['$scope', 'roomsService'];
        constructor(private $scope: IRoomsScope, private roomsService: app.services.IRoomsService) {                        
            //sciope rooms z getRooms
            super();
            this.$scope.rooms = this.getRooms();
        }

        public getRooms(): app.models.Room[] {
            return this.roomsService.getRooms();
        }

        public registerEvents(): void {
            this.$scope.$on(app.events.RoomsEvents.RoomAdded, (event) => {
                // tu cialo eventu
                this.$scope.rooms = this.getRooms();
            });
        }
    }

    angular.module('app').controller('RoomsController', RoomsController);
}