var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
/// <reference path="../models/room.ts" />
/// <reference path="basecontroller.ts" />
var app;
(function (app) {
    var controllers;
    (function (controllers) {
        var RoomsController = (function (_super) {
            __extends(RoomsController, _super);
            function RoomsController($scope, roomsService) {
                _super.call(this);
                this.$scope = $scope;
                this.roomsService = roomsService;
                this.registerEvents();
                this.$scope.rooms = app.models.Room[1];
                var rooms = this.getRooms();
                debugger;
                this.$scope.name = "Piotr";
            }
            RoomsController.prototype.getRooms = function () {
                var self = this;
                this.roomsService.roomsCallback = function (rooms) {
                    self.$scope.rooms = rooms;
                };
                this.roomsService.getRooms();
            };
            RoomsController.prototype.setRooms = function (rooms) {
                this.$scope.rooms = rooms;
            };
            RoomsController.prototype.registerEvents = function () {
                var _this = this;
                this.$scope.$on(app.events.RoomsEvents.RoomAdded, function (event) {
                    _this.getRooms();
                });
            };
            RoomsController.$inject = ['$scope', 'roomsService'];
            return RoomsController;
        }(controllers.BaseController));
        controllers.RoomsController = RoomsController;
        angular.module('app').controller('RoomsController', RoomsController);
    })(controllers = app.controllers || (app.controllers = {}));
})(app || (app = {}));
//# sourceMappingURL=RoomsController.js.map