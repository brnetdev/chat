/// <reference path="../app.ts" />
module app.controllers {
    export interface IMainController {
        
    }

    export interface IMainScope extends ng.IScope {
        roomsLoaded: boolean;
    }

    export class MainController implements IMainController {
        public static $inject = ["$scope"];
        constructor(private $scope: IMainScope) {
            $scope.roomsLoaded = false;            
        }

    }
    angular.module('app').controller('MainController', MainController);
}