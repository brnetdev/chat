/// <reference path="../models/room.ts" />
var app;
(function (app) {
    var controllers;
    (function (controllers) {
        var RoomsController = (function () {
            function RoomsController($scope, roomsService) {
                this.$scope = $scope;
                this.roomsService = roomsService;
            }
            RoomsController.prototype.getRooms = function () {
                this.$scope.rooms = this.roomsService.getRooms();
            };
            RoomsController.prototype.registerEvents = function () {
                this.$scope.$on(app.events.RoomsEvents.RoomAdded, function (event) {
                    // tu cialo eventu
                });
            };
            RoomsController.inject = ['$scope', 'roomsService'];
            return RoomsController;
        }());
        controllers.RoomsController = RoomsController;
        angular.module('app').controller('RoomsController', RoomsController);
    })(controllers = app.controllers || (app.controllers = {}));
})(app || (app = {}));
//# sourceMappingURL=RoomsController.js.map