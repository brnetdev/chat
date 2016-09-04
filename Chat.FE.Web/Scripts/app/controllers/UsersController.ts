/// <reference path="../models/user.ts" />
/// <reference path="basecontroller.ts" />
module app.controllers {
    export interface IUsersController {
        getUsers(): void;
    }

    export interface IUsersScope extends ng.IScope {
        users: string[];
    }

    export class UsersController extends BaseController implements IUsersController {        

        private _usersProxy: IUsersHubProxy;
        public static $inject = ['$scope', 'usersService'];
        constructor(private $scope: IUsersScope, private usersService: app.services.IUsersService) {            
            super();
            this._usersProxy = $.connection.usersHub;
            this.$scope.users = [];
            this._usersProxy.client.newUsersLoggedIn = (login: string) => this.$scope.users.push(login);
            this.getUsers();            
        }

        public getUsers(): void {
            var self = this;
            this.usersService.getUsers().then(function (result: any) {
                var usersarr = result.data;
                self.$scope.users = [];
                angular.forEach(usersarr, function (value: string) {                    
                    self.$scope.users.push(value);
                });
            });
        }

        public registerEvents(): void {
        }

        
    }
    angular.module('app').controller('UsersController', UsersController);
}