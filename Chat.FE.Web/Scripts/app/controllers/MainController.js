/// <reference path="../app.ts" />
var app;
(function (app) {
    var controllers;
    (function (controllers) {
        var MainController = (function () {
            function MainController($scope) {
                this.$scope = $scope;
                var self = this;
                $scope.$on('$destroy', function () {
                    console.log("Niszcze MainController");
                });
                this.$scope.$on(app.events.RoomsEvents.RoomStatusUpdated, function (event, room) {
                    //aktualizacja stanu                                
                    //this.$scope.room = <string>room;
                });
            }
            MainController.$inject = ["$scope"];
            return MainController;
        }());
        controllers.MainController = MainController;
        angular.module('app').controller('MainController', MainController);
    })(controllers = app.controllers || (app.controllers = {}));
})(app || (app = {}));
//# sourceMappingURL=MainController.js.map