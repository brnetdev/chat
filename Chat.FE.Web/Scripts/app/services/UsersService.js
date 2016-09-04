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
                debugger;
                var self = this;
                return this.$http.get('/Chat.FE.Web/api/Users');
            };
            UsersService.$inject = ['$http'];
            return UsersService;
        }());
        services.UsersService = UsersService;
        angular.module('app').service('usersService', UsersService);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
//# sourceMappingURL=UsersService.js.map