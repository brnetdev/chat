module app.controllers {
    export interface IChatController {
        sendMessage(message: string): void;
        newMessageRecived(message: string, login: string);
    }

    export interface IChatScope extends ng.IScope {
        room: string;
        messages: string[];        
        message: string;
        broadcastMessage(message: string): void;
    }

    export class ChatController extends BaseController implements IChatController {
        private _chatProxy: IChatHubProxy;

        public static $inject = ['$scope'];
        constructor(private $scope: IChatScope) {
            super();
            self._chatProxy = $.connection.chatHub;
            self._chatProxy.client.newMessageRecived = (message: string, login: string) => this.newMessageRecived(message, login);            
            var self = this;
            this.$scope.messages = [];
            this.$scope.broadcastMessage = (message: string) => this.sendMessage(message);

            
        }
        public sendMessage(message: string): void {                        
            this._chatProxy.server.broadcastMessage(message, this.$scope.room);
            this.$scope.message = "";
        }

        public newMessageRecived(message: string, login: string): void {            
            this.$scope.messages.push(login + ": " + message);            
        }

        registerEvents(): void {

        }
    }

    angular.module('app').controller('ChatController', ChatController);
}