/// <reference path="../models/user.ts" />
module app.services {
    export interface IUsersService {
        getUsers(): app.models.IUser[];
    }

    export class UsersService implements IUsersService {

        public static inject = ['$http'];
        constructor(private $http: ng.IHttpService) {
        }

        getUsers(): app.models.IUser[] {
            var users = [];            
            users.push(new app.models.User());
            return users;
        }
    }

    angular.module('app').service('usersService', UsersService);
}