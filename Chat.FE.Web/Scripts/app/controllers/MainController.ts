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
            
            $scope.$on('$destroy', function () {
                console.log("Niszcze MainController");
            });

            this.$scope.$on(app.events.RoomsEvents.RoomStatusUpdated, (event, room) => {
                //aktualizacja stanu                                
                //this.$scope.room = <string>room;
            });

        }

    }
    angular.module('app').controller('MainController', MainController);
}