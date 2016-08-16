/// <reference path="../models/room.ts" />
/// <reference path="basecontroller.ts" />
module app.controllers {
    export interface IRoomsController {
        getRooms(): void;
    }

    export interface IRoomsScope extends ng.IScope {
        rooms: app.models.Room[];
        name: string;
    }
    
    export class RoomsController extends BaseController implements IRoomsController {

        public static $inject = ['$scope', 'roomsService'];
        constructor(private $scope: IRoomsScope, private roomsService: app.services.IRoomsService) {                                
            super();
            this.registerEvents();
            this.$scope.rooms = app.models.Room[1];
            var rooms = this.getRooms();
            debugger;
            this.$scope.name = "Piotr";
        }

        public getRooms(): void {
            var self = this;
            this.roomsService.roomsCallback = function (rooms: app.models.IRoom[]) {                            
                console.log('RoomServiceCallback', rooms);
                self.$scope.rooms = rooms;                
            }
            this.roomsService.getRooms();
        }

        public setRooms(rooms: app.models.Room[]) {
            this.$scope.rooms = rooms;
        }

        public registerEvents(): void {
            this.$scope.$on(app.events.RoomsEvents.RoomAdded, (event) => {                
                this.getRooms();
            });
        }
    }

    angular.module('app').controller('RoomsController', RoomsController);
}