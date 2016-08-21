/// <reference path="../app.ts" />
module app.controllers {
    export interface IMainController {
        
    }

    export interface IMainScope extends ng.IScope {
        loaded: boolean;
    }

    export class MainController implements IMainController {
        public static $inject = ["$scope"];
        constructor(private $scope: IMainScope) {
            var self = this;
            $.connection.hub.logging = true;
            $.connection.hub.start().done(function () {
                self.$scope.loaded = true;
                self.$scope.$apply();
            });            
        }

    }
    angular.module('app').controller('MainController', MainController);
}