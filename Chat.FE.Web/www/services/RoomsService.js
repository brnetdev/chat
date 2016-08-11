/// <reference path="../models/room.ts" />
var app;
(function (app) {
    var services;
    (function (services) {
        var RoomService = (function () {
            function RoomService($http) {
                this.$http = $http;
            }
            RoomService.prototype.getRooms = function () {
                return [];
            };
            RoomService.$inject = ['$http'];
            return RoomService;
        }());
        services.RoomService = RoomService;
        angular.module('app').service('RoomService', RoomService);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
