/// <reference path="../models/room.ts" />
var app;
(function (app) {
    var controllers;
    (function (controllers) {
        var RoomsController = (function () {
            function RoomsController($scope, roomService) {
                this.$scope = $scope;
                this.roomService = roomService;
            }
            RoomsController.prototype.getRooms = function () {
                this.$scope.rooms = this.roomService.getRooms();
            };
            RoomsController.prototype.registerEvents = function () {
                this.$scope.$on(app.events.RoomsEvents.RoomAdded, function (event) {
                    // tu cialo eventu
                });
            };
            RoomsController.inject = ['$scope', 'roomService'];
            return RoomsController;
        }());
        controllers.RoomsController = RoomsController;
        angular.module('app').controller('RoomsController', RoomsController);
    })(controllers = app.controllers || (app.controllers = {}));
})(app || (app = {}));
