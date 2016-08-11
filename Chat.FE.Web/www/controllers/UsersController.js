var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
/// <reference path="../models/user.ts" />
/// <reference path="basecontroller.ts" />
var app;
(function (app) {
    var controllers;
    (function (controllers) {
        var UsersController = (function (_super) {
            __extends(UsersController, _super);
            function UsersController($scope, usersService) {
                _super.call(this);
                this.$scope = $scope;
                this.usersService = usersService;
                this.getUsers();
            }
            UsersController.prototype.getUsers = function () {
                this.$scope.users = this.usersService.getUsers();
            };
            UsersController.prototype.registerEvents = function () {
            };
            UsersController.$inject = ['$scope', 'usersService'];
            return UsersController;
        }(controllers.BaseController));
        controllers.UsersController = UsersController;
        angular.module('app').controller('UsersController', UsersController);
    })(controllers = app.controllers || (app.controllers = {}));
})(app || (app = {}));
