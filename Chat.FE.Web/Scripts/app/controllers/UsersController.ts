/// <reference path="../models/user.ts" />
/// <reference path="basecontroller.ts" />
module app.controllers {
    export interface IUsersController {
        getUsers(): void;
    }

    export interface IUsersScope extends ng.IScope {
        users: app.models.IUser[];
    }

    export class UsersController extends BaseController implements IUsersController {        

        public static $inject = ['$scope', 'usersService'];
        constructor(private $scope: IUsersScope, private usersService: app.services.IUsersService) {            
            super();
            this.getUsers();
        }

        public getUsers(): void {
            this.$scope.users = this.usersService.getUsers();
        }

        public registerEvents(): void {
        }

        
    }
    angular.module('app').controller('UsersController', UsersController);
}