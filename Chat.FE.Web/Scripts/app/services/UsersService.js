/// <reference path="../models/user.ts" />
var app;
(function (app) {
    var services;
    (function (services) {
        var UsersService = (function () {
            function UsersService($http) {
                this.$http = $http;
            }
            UsersService.prototype.getUsers = function () {
                var users = [];
                users.push(new app.models.User());
                return users;
            };
            UsersService.inject = ['$http'];
            return UsersService;
        }());
        services.UsersService = UsersService;
        angular.module('app').service('usersService', UsersService);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
