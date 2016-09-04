/// <reference path="../models/user.ts" />
module app.services {
    export interface IUsersService {
        getUsers(): ng.IPromise<string>;
    }

    export class UsersService implements IUsersService {

        public static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) {
        }

        getUsers(): ng.IPromise<string> {
            var users = [];            
            debugger;
            var self = this;
            return this.$http.get('/Chat.FE.Web/api/Users');            
        }
    }

    angular.module('app').service('usersService', UsersService);
}