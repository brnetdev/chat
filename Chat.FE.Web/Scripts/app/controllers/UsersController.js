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
                var _this = this;
                _super.call(this);
                this.$scope = $scope;
                this.usersService = usersService;
                this._usersProxy = $.connection.usersHub;
                this.$scope.users = [];
                this._usersProxy.client.newUsersLoggedIn = function (login) { return _this.$scope.users.push(login); };
                this.getUsers();
            }
            UsersController.prototype.getUsers = function () {
                var self = this;
                this.usersService.getUsers().then(function (result) {
                    var usersarr = result.data;
                    self.$scope.users = [];
                    angular.forEach(usersarr, function (value) {
                        self.$scope.users.push(value);
                    });
                });
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
//# sourceMappingURL=UsersController.js.map