/// <reference path="../app.ts" />
var app;
(function (app) {
    var controllers;
    (function (controllers) {
        var MainController = (function () {
            function MainController($scope) {
                this.$scope = $scope;
                var self = this;
                $.connection.hub.logging = true;
                $.connection.hub.start().done(function () {
                    self.$scope.loaded = true;
                    self.$scope.$apply();
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